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
        /// Gets assembly copyright information.
        /// </summary>
        public string Copyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

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
                
                // Line 1: Full product title.
                versionStringBuilder.Append(((AssemblyProductAttribute)nameAttributes[0]).Product)
                                    .Append(Environment.NewLine);

                // Line 2: Detailed assembly version information.
                versionStringBuilder.Append(Application.Current.TryFindResource("Version").ToString()).Append(" ");
                versionStringBuilder.Append(Assembly.GetExecutingAssembly().GetName().Version.ToString())
                                    .Append(Environment.NewLine);

                // Line 3: Source code revision information.
                versionStringBuilder.Append(Application.Current.TryFindResource("Revision").ToString())
                                    .Append(" ")
                                    .Append(
                                        ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion)
                                    .Append(Environment.NewLine);
            }

            // Line 4: Platform information.
            versionStringBuilder.Append(Environment.Is64BitProcess ? "64 bit" : "32 bit").Append(", .NET ");
            versionStringBuilder.Append(Assembly.GetExecutingAssembly().ImageRuntimeVersion.ToString());

            Version = versionStringBuilder.ToString();
        }
    }
}