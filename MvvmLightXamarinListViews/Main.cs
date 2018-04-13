﻿using System;
using MvvmLightXamarinListViews.Core;
using UIKit;

namespace MvvmLightXamarinListViews
{
    public class Application
    {
        private static readonly Lazy<ViewModelLocator> Locator = new Lazy<ViewModelLocator>(() => new ViewModelLocator());
        public static ViewModelLocator ViewModelLocator => Locator.Value;

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}