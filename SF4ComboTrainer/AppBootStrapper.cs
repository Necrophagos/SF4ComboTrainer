namespace SF4ComboTrainer
{
    using System.Collections.Generic;
    using System.Reflection;

    using Caliburn.Micro;

    using SF4ComboTrainer.ViewModels;

    public class AppBootStrapper : Bootstrapper<MainViewModel>
    {
        /// <summary>
        /// Select the assemblies that contain model views.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());
            assemblies.Add(Assembly.Load("SF4ComboTrainer.Home"));
            assemblies.Add(Assembly.Load("SF4ComboTrainer.Input"));
            assemblies.Add(Assembly.Load("SF4ComboTrainer.Library"));
            assemblies.Add(Assembly.Load("SF4ComboTrainer.TimeLine"));

            return assemblies;
        }

        //protected override void OnStartup(object sender, StartupEventArgs e)
        //{
        //    base.OnStartup(sender, e);
        //}

        public AppBootStrapper() : base() { }
    }
}
