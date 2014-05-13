namespace FrameTrapped.StreetFighterLibrary
{
    using System.Collections.Generic;
    using System.Reflection;
    using Caliburn.Micro;
    using FrameTrapped.Common.Utilities;
    using FrameTrapped.Input;
    using FrameTrapped.StreetFighterLibrary.ViewModels;

    public class AppBootStrapper : Bootstrapper<StreetFighterLibraryViewModel>
    {
        /// <summary>
        /// Select the assemblies that contain model views.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());
            assemblies.Add(Assembly.Load("FrameTrapped.Input"));  

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
