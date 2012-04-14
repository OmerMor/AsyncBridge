require 'rake/clean'

#task :default do
#    $stderr.puts "Howdy, World"


DOT_NET_PATH = "#{ENV["SystemRoot"]}\\Microsoft.NET\\Framework\\v4.0.30319"
NUNIT_EXE = "../packages/NUnit.2.5.10.11092/tools/nunit-console.exe"
NUGET_EXE = "../packages/NuGet.CommandLine.1.7.0/tools/NuGet.exe"
SOURCE_PATH = ".."
OUTPUT_PATH = "../output"
configurations = ["Release"]
 
CLEAN.include(OUTPUT_PATH)

task :default => ["clean", "build:all"]
 
namespace :build do
  
	task :all => [:compile, :pack]
      
	desc "Build solutions using MSBuild"
	task :compile do
		solutions = FileList["#{SOURCE_PATH}/**/*.sln"]
		solutions.each do |solution|
			configurations.each do |config|
				sh "#{DOT_NET_PATH}/msbuild.exe /p:Configuration=#{config} #{solution}"
			end
		end
	end

	desc "Package with NuGet"
	task :pack => [:compile] do
		mkdir OUTPUT_PATH unless File.exists?(OUTPUT_PATH)
		specs = FileList["#{SOURCE_PATH}/**/*.nuspec"]
		specs.each do |spec|
			folder = File.dirname(spec)
			sh "#{NUGET_EXE} pack #{spec} -BasePath #{folder} -OutputDirectory #{OUTPUT_PATH}"
		end
	end	
	
	desc "Publish with NuGet"
	task :publish => [:pack] do
		packages = FileList["#{OUTPUT_PATH}/*.nupkg"]
		packages.each do |package|
			sh "#{NUGET_EXE} push #{package}"
		end
	end	
end
