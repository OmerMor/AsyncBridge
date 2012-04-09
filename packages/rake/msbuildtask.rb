require 'rake'
require 'rake/tasklib'

module Rake

  class MsbuildTask < TaskLib
    # Name of the main, top level task.  (default is :msbuild)
    attr_accessor :name, :solutions, :config, :tool, :config
    attr_accessor :cleanbefore

    VERS_TMPL =  { :devenv =>  "devenv /!tsk! !config! !solution!",
                   :msbuild => "msbuild /t:!tsk! /p:Configuration=!config! !solution!"                   
                 }

    # Create an NUnit task named nunit.  Default task name is +nunit+.
    def initialize(name=:msbuild) # :yield: self
      @name = name
      @tool = :msbuild
      @config = "Debug"
      yield self if block_given?
      define
    end
    
    # Create the tasks defined by this task lib.
    def define
      task name do
        tsks = []
        tsks << "Clean" if @cleanbefore
        tsks << "Build" 
        cmd = VERS_TMPL[@tool].gsub( "!config!", @config )
        solutions.each do |solution|
          tsks.each { |tsk| sh cmd.gsub( "!tsk!", tsk ).gsub( "!solution!", solution ) }
        end
      end
      self
    end
  end
end
