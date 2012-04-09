require 'rake'
require 'rake/tasklib'

module Rake
  class CscTask < TaskLib
    # Name of the main, top level task.  (default is :nunit)
    attr_accessor :name, :files, :compiler, :flags, :config, :refs

    def initialize(name=:nunit) # :yield: self
      @name = name
      compiler = "mcs"
      compiler = "csc" if /win32/.match( RUBY_PLATFORM )
        
      yield self if block_given?
      define
    end
    
    def define
      task name do
        flaglist = ""
        flags.each { |f| flaglist << " /#{f}" } if flags
        reflist = "/reference:%s" % refs.join( "," ) if refs
        files.each do |library|
          sh "#{@compiler} #{flaglist} #{config} #{reflist}"
        end
      end
      self
    end

    def reflist
    end

    def config
      "/#{@config}" if @config && @config.downcase == "debug"
    end
  end
end
