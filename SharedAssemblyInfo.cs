﻿using System.Reflection;
using System.Resources;

// WARNING this file is shared accross multiple projects

[assembly: AssemblyProduct("ASP.NET AJAX Control Toolkit")]
[assembly: AssemblyCopyright("Copyright © CodePlex Foundation 2012-2016")]
[assembly: AssemblyCompany("CodePlex Foundation")]

[assembly: AssemblyVersion("16.1.1.0")]
[assembly: AssemblyFileVersion("16.1.1.0")]

[assembly: NeutralResourcesLanguage("en-US")]

#if DEBUG
[assembly: AssemblyDescription("ASP.NET AJAX Control Toolkit (debug version)")]
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyDescription("ASP.NET AJAX Control Toolkit")]
[assembly: AssemblyConfiguration("Release")]
#endif