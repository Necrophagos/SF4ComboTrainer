namespace FrameTrapped
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using Microsoft.VisualBasic;

    public class Program
    {
        [STAThreadAttribute]
        public static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;

            App.Main();

        }

        static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string info = e.ExceptionObject.ToString();
            string message = "Well bummer, an error occured!\n Well this is in beta and I need all the crash info I can get. Send any log info below to tpiddock@gmail.com\n\nPress OK to restart the app, this may take a moment.";

            if (Interaction.InputBox(message, "Oops! Something bad happened...", info) != string.Empty)
            {
                System.Diagnostics.Process.Start(
                    System.Reflection.Assembly.GetEntryAssembly().Location,
                    string.Join(" ", Environment.GetCommandLineArgs()));
                Environment.Exit(1);
            }
        }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(args.Name);

            string path = assemblyName.Name + ".dll";
            if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
            {
                path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);
            }

            using (Stream stream = executingAssembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                    return null;

                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }
    }
}