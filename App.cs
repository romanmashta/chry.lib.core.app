using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Autofac;
using Cherry.Lib.Core.App.Extension;
using Cherry.Lib.Core.Identity.Clients.Contracts;
using Serilog;

namespace Cherry.Lib.Core.App
{
    public class App
    {
        private readonly IAuthenticationClientService _authenticationService;
        
        public string ApplicationName { get; set; }
        public string LogoUrl { get; set; }
        public List<AppModule> Modules { get; } = new List<AppModule>();
        public string AppHeaderUrl { get; set; }
        public string Icon { get; set; }

        //public bool IsAuthenticated => _authenticationService.CurrentUser != null;
        public bool IsAuthenticated { get; set; }
        
        public EventHandler AuthStateChanged { get; set; }

        public App(IEnumerable<AppModule> modules, IAuthenticationClientService authenticationService)
        {
            Log.Information("Instantiating app with modules {@modules}", modules.Select(m=>m.GetType().FullName));
            Modules.AddRange(modules);
            _authenticationService = authenticationService;
        }

        public void Start()
        {
            Log.Information("Starting app");

            foreach (var module in Modules)
            {
                module.Start();
            }
            
            _authenticationService.OnAuthStateChanged += AuthenticationServiceOnOnAuthStateChanged;   
        }

        private void AuthenticationServiceOnOnAuthStateChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"{IsAuthenticated} AuthStateChanged");
            AuthStateChanged?.Invoke(sender, e);
        }

        public void Stop()
        {
            Log.Information("Stopping app");
            foreach (var module in Modules)
            {
                module.Stop();
            }
        }

        public void Login()
        {
            IsAuthenticated = true;
            AuthStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}