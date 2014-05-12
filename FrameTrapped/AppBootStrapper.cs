namespace FrameTrapped
{
    using System.Collections.Generic;
    using System.Reflection;
    using Caliburn.Micro;
    using FrameTrapped.Common.Utilities;
    using FrameTrapped.ViewModels;

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
            assemblies.Add(Assembly.Load("FrameTrapped.Home"));
            assemblies.Add(Assembly.Load("FrameTrapped.Input"));
            assemblies.Add(Assembly.Load("FrameTrapped.StreetFighterLibrary"));
            assemblies.Add(Assembly.Load("FrameTrapped.TimeLine"));

            return assemblies;
        }

        protected override void OnExit(object sender, System.EventArgs e)
        {
            Roadie.Instance.Dispose();
            base.OnExit(sender, e);
        }

        public AppBootStrapper() : base() {
          
        }
    }
}
