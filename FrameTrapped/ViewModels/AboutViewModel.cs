namespace FrameTrapped.ViewModels
{


    using System;
    using System.Reflection;
    using System.Text;
    using System.Windows;

    using Caliburn.Micro;

    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    /// Exclude 'AboutViewModel' and all its members from obfuscation 
    public class AboutViewModel : Screen
    {
  
        /// <summary>
        /// Gets the title string.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets assembly version.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        /// <param name="isLicensed">Whether the application is licensed.</param>
        public AboutViewModel()
        {
            DisplayName = Application.Current.TryFindResource("AboutTitle").ToString();

            // Construct the version information.
            StringBuilder versionStringBuilder = new StringBuilder();

            object[] attributes =
                Assembly.GetExecutingAssembly()
                        .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);

            object[] nameAttributes = 
                Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyProductAttribute), false);

            if (attributes.Length != 0)
            {   
                versionStringBuilder.Append(((AssemblyProductAttribute)nameAttributes[0]).Product)
                                    .Append(Environment.NewLine);
                 
                versionStringBuilder.Append(Application.Current.TryFindResource("Version").ToString()).Append(" ");
                versionStringBuilder.Append(Assembly.GetExecutingAssembly().GetName().Version.ToString())
                                    .Append(Environment.NewLine);
                 
                versionStringBuilder.Append(Application.Current.TryFindResource("Revision").ToString())
                                    .Append(" ")
                                    .Append(((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion)
                                    .Append(Environment.NewLine);
            }

            // Line 4: Platform information.
            versionStringBuilder.Append(Environment.Is64BitProcess ? "64 bit" : "32 bit").Append(", .NET ");
            versionStringBuilder.Append(Assembly.GetExecutingAssembly().ImageRuntimeVersion.ToString());

            Version = versionStringBuilder.ToString();
            Title = string.Format("{0} {1} : {2}", "About", Application.Current.TryFindResource("Title").ToString(), Version);
        }
    }
}