class Deployer
  attr :options

  def initialize( opts = {} )
    @options ||= {}
    defaults = { 
      :name => 'bld_rel',
      :deploy_path => './bld_rel/',
      :src_path => './',
      :paths => %w[ Views Content bin ],
      :extensions => %w[ vm boo jpg gif png bmp css js html aspx asax ashx asmx ],
      :file_ignore => /\.(scc|svn)$/,
      :dir_ignore => /obj|lib/
    }
    [defaults, opts].each { |o| @options.merge! o }    

    yield self if block_given?
  end

  def push
    target_name = @options[:name].to_s
    src = @options[:src_path]
    paths = @options[:deploy_path].to_a
    paths.each do |rawpth|      
      pth = __verify_deploy_path
      __burn_existing_content( pth )

      fps = @options[:paths].collect { |p| "#{src}/#{p}/**/*" }
      cfg = FileList[ "#{src}/**/*.config-#{target_name}" ]
      cfg = FileList[ "#{src}/**/*.config" ] unless cfg && cfg.length > 0
      cfg.exclude( /bin\/(Debug|Release)\/.*\.config.*$/ )
      fpi = @options[:extensions].collect { |e| "#{src}/*.#{e}" }
      roots = FileList[ *fpi ]
      files = FileList[ *fps ]
      files += roots if roots
      files += cfg if cfg
      files.each { |f| __copy_file( f, pth ) }

      ver_id = `svnversion .`
      `echo > "#{pth}/REVISION_#{ver_id}"`
      __cleanup_deploy_path( pth )
      puts "deployed to #{pth}"
    end      
  end

  private
  def __verify_deploy_path
    target_path = @options[:deploy_path]
    return target_path unless /\\\\.*\\.*/.match( target_path )
    `net use o: /delete` if File.exist?( "o:" )     
    `net use o: #{target_path} /persistent:no`
    return "o:/"
  end

  def __cleanup_deploy_path(path)
    return unless path == "o:/"
    `net use o: /delete` if File.exist?( "o:" ) 
  end

  def __burn_existing_content(pth)
    FileList[ "#{pth}/*" ].each { |f| FileUtils.rm_rf f }
  end

  def __targetify(targ, pth)
    src = @options[:src_path]
    ret = pth + targ.gsub( "#{src}/" , '' )
    tgt_re = /(\.[A-Za-z_0-9]+)-.*/
    ret.gsub!( tgt_re, $1 ) if tgt_re.match( ret )
    ret
  end

  def __copy_file(orig, pth)
    targ = __targetify( orig, pth )
    dir = File.dirname( targ )
    FileUtils.mkdir_p( dir ) unless File.exists?( dir )    
    return if File.directory? orig

    FileUtils.rm_rf targ if File.exists? targ
    FileUtils.cp orig, targ
  end
end
