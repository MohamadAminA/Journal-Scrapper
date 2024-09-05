﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

public class WebScraper
{
    public static IWebDriver driver;
    private static Random random = new Random();
    private static List<string> USER_AGENTS = new List<string>
{
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.5845.140 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.5790.102 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:116.0) Gecko/20100101 Firefox/116.0",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:115.0) Gecko/20100101 Firefox/115.0",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.5735.199 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:114.0) Gecko/20100101 Firefox/114.0",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.5672.93 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.5615.137 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:113.0) Gecko/20100101 Firefox/113.0",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5563.111 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:112.0) Gecko/20100101 Firefox/112.0",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5481.178 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:111.0) Gecko/20100101 Firefox/111.0",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.5414.119 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0"
};


    public static string GetPageContent(string url)
    {
        // Random random = new Random();
        // int randomWait = random.Next(500, 3000); // Adjust the bounds

        if (url.Contains(".pdf") || url.Contains(".rar") || url.Contains(".zip") || url.Contains(".txt"))
        {
            // Console.WriteLine("Site is file");
            return "";
        }

        if (url.Contains("semanticscholar.org") || url.Contains("sciencedirect.com") || url.Contains("researchgate.net") ||
            url.Contains("link.springer.com") || url.Contains("sid.ir") || url.Contains("magiran.com") ||
            url.Contains("scholar.google.com/scholar?cluster") || url.Contains("ieeexplore.ieee.org"))
        {
            // Console.WriteLine("Skipping site");
            return "";
        }

        if (driver == null)
        {
            int randomIndex = random.Next(USER_AGENTS.Count);
            string randomString = USER_AGENTS[randomIndex];

            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("download_restrictions", 3);
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--allow-insecure-localhost");
            options.AddArgument("--disable-web-security");
            options.AddArgument("--allow-running-insecure-content");
            // options.AddArgument("--remote-debugging-port=" + DEBUGGING_PORT);
            options.AddArgument("--remote-allow-origins=*");
            options.AddArgument("--disable-search-engine-choice-screen");
            options.AddArgument("--disk-cache-size=0");
            options.AddArgument("--disable-application-cache");
            options.AddArgument("user-agent=" + randomString);
            // options.AddArgument("Origin=" + origin);
            // options.AddArgument("Host=" + host);
            // options.AddArgument("Referer=" + url);
            options.AddArgument("Accept=*/*");
            options.AddArgument("Accept-Encoding=gzip, deflate, br");
            // options.AddArgument("Accept-Language=en-US,en;q=0.9");
            options.AddArgument("Accept-Charset=ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            options.AddArgument("Connection=keep-alive");
            options.AddArgument("X-user-agent=" + randomString);
            options.AddArgument("Content-Type=application/json");
            options.AddArgument("Pragma=no-cache");
            options.AddArgument("Cache-Control=no-cache");
            // options.AddArgument("disable-infobars");
            // options.AddArgument("user-data-dir=" + chromeProfile);
            // options.AddArgument("profile-directory=Default");

            options.PageLoadStrategy = PageLoadStrategy.Eager;

            try
            {
                // string killCommand = "taskkill /F /IM chrome.exe /T";
                // Runtime.getRuntime().exec(killCommand);
            }
            catch (Exception e) { }

            string extraFolderPath = FindDirectoryInParents("Extra");
            string chromeDriverPath = Path.Combine(extraFolderPath, "chromedriver.exe");
            driver = new ChromeDriver(chromeDriverPath, options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        try
        {
            if(!url.StartsWith("http"))
            url = "https://" + url.Replace("https://", "").Replace("http://", "");
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            // if (HandleCaptcha(driver)) {
            //     Thread.Sleep(1000);
            //     if (driver.Url.Contains("google.com/sorry")) {
            //         Console.WriteLine("Captcha didn't solve");
            //     }
            // }
            return driver.PageSource;
        }
        catch (Exception e)
        {
            // Console.WriteLine("Site cannot load : " + url);
        }

        // long startTime = System.currentTimeMillis();
        // long maxLoadTime = 10000; // 10 ثانیه

        // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
        // wait.Until(d =>
        // {
        //     IWebElement element = d.FindElement(By.TagName("body"));
        //     return element != null;
        // });

        // Thread.Sleep(randomWait);

        return "";
    }
    private static string FindDirectoryInParents(string directoryName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();

        while (!string.IsNullOrEmpty(currentDirectory))
        {
            string potentialPath = Path.Combine(currentDirectory, directoryName);
            if (Directory.Exists(potentialPath))
            {
                return potentialPath;
            }

            currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
        }

        throw new DirectoryNotFoundException($"The directory '{directoryName}' was not found in any parent directories.");
    }
    public static string GetFullURL(string subUrl,string fullUrl,bool absolute = false)
    {
        var url = new Uri(fullUrl);

        if (!absolute)
        {
            Uri absoluteUrl = new Uri(url, subUrl);
            return absoluteUrl.ToString();
        }
       
        if (subUrl.StartsWith("/"))
            subUrl = subUrl.Substring(1);

        if (!subUrl.Contains(url.Host))
            subUrl = url.Host + "/" + subUrl;

        if (!subUrl.Contains("http"))
            subUrl = url.Scheme + "://" + subUrl;

        return subUrl;
    }
}
