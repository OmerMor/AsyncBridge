require 'rake'
require 'rake/tasklib'

module Rake
  class NUnitTask < TaskLib
    # Name of the main, top level task.  (default is :nunit)
    attr_accessor :name, :files, :xml, :path_to_console, :config

    # Create an NUnit task named nunit.  Default task name is +nunit+.
    def initialize(name=:nunit) # :yield: self
      @name = name
      ntpl = "/program files/nunit*/bin/nunit-console.exe"
      lst = %w[ c d e ].collect { |c| "#{c}:#{ntpl}" }
      nufl = FileList[ *lst ]
      puts "nufl: #{nufl.inspect}"
      @path_to_console = %q[ "d:\\program files\\nunit 2.4.3\bin\nunit-console" ]
      @path_to_console = nufl.first if nufl && nufl.length > 0
      yield self if block_given?
      define
    end
    
    # Create the tasks defined by this task lib.
    def define
      task name do
        files.each do |library|
          sh "#{@path_to_console} #{xml} #{config} #{library}"
        end
      end
      self
    end

    def xml
      "/xml=#{@xml}" if @xml
    end
   
    def config
      "/config=#{@config}" if @config
    end
  end
end
