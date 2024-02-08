﻿using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.DataProtection;

namespace DXApplication.Controllers {
    public class DefaultDashboardController(DashboardConfigurator configurator,
      IDataProtectionProvider? dataProtectionProvider = null) 
        : DashboardController(configurator, dataProtectionProvider) {
  }
}