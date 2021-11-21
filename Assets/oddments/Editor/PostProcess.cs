#if UNITY_IOS || UNITY_IPHONE
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.Collections.Generic;
using UnityEngine;

namespace Treeplla{
    public class PostProcess
    {
        private const string AppLovinMaxResourcesDirectoryName = "AppLovinMAXResources";
        private const bool UseMax = true;

        [PostProcessBuildAttribute(int.MaxValue)]
        public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
        {
            var plistPath = Path.Combine(buildPath, "Info.plist");
            var plist = new PlistDocument();
            plist.ReadFromFile(plistPath);

            plist.root.SetBoolean("ITSAppUsesNonExemptEncryption", false);
            //plist.root.SetString("NSUserTrackingUsageDescription", "This identifier will be used to deliver personalized ads to you.");
            //plist.root.SetString("FacebookAppID", "580882013229001");

            // var array = plist.root.CreateArray("CFBundleURLTypes");
            // var urlDict = array.AddDict();
            // var urlInnerArray = urlDict.CreateArray("CFBundleURLSchemes");
            // urlInnerArray.AddString("fb580882013229001");

            File.WriteAllText(plistPath, plist.WriteToString());


            var projectPath = PBXProject.GetPBXProjectPath(buildPath);
            var project = new PBXProject();
            project.ReadFromFile(projectPath);

            var targetGuid = project.GetUnityMainTargetGuid();
            project.AddCapability(targetGuid, PBXCapabilityType.InAppPurchase);
            project.SetBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");
            
            //var fileGuid = project.AddFile(Path.Combine(buildPath, "GoogleService-Info.plist"), Path.Combine(buildPath, "GoogleService-Info.plist"));
            //project.AddFileToBuild(targetGuid, fileGuid);

            if(UseMax)
            {
                var loadInst = AssetDatabase.LoadAssetAtPath<AppNameLocalize>("Assets/Treeplla/Editor/AppNameLocalize.asset");
                if(loadInst != null)
                {
                    System.Action<string, string> SaveLocalFile = (localizeString, localeCode) => {
                        var path = GetMaxLocalFilePath(buildPath, localeCode);
                        var localizedDescriptionLine = "\"CFBundleDisplayName\" = \"" + localizeString + "\";\n";
                        // File already exists, update it in case the value changed between builds.
                        if (File.Exists(path))
                        {
                            var output = new List<string>();
                            var lines = File.ReadAllLines(path);
                            var keyUpdated = false;
                            foreach (var line in lines)
                            {
                                if (line.Contains("CFBundleDisplayName"))
                                {
                                    output.Add(localizedDescriptionLine);
                                    keyUpdated = true;
                                }
                                else
                                {
                                    output.Add(line);
                                }
                            }

                            if (!keyUpdated)
                            {
                                output.Add(localizedDescriptionLine);
                            }

                            File.WriteAllText(path, string.Join("\n", output.ToArray()) + "\n");
                        }
                    };
                    SaveLocalFile(loadInst.en, "en");
                    SaveLocalFile(loadInst.ko, "ko");
                    SaveLocalFile(loadInst.ja, "ja");
                    SaveLocalFile(loadInst.de, "de");
                    SaveLocalFile(loadInst.es, "es");
                    SaveLocalFile(loadInst.fr, "fr");
                    SaveLocalFile(loadInst.zhHans, "zh-Hans");
                    SaveLocalFile(loadInst.zhHant, "zh-Hant");
                }
            }
            else
            {
                var localizeList = new List<string>();
                localizeList.Add("Base.lproj");
                localizeList.Add("ko.lproj");
                localizeList.Add("ja.lproj");
                localizeList.Add("en.lproj");

                Dictionary<string, string> folders = new Dictionary<string, string>();
                foreach (var data in localizeList)
                {
                    if (!Directory.Exists(buildPath + data))
                        Directory.CreateDirectory(buildPath + "/" + data);
                    else
                    {
                        FileUtil.DeleteFileOrDirectory(buildPath + data);
                        Directory.CreateDirectory(buildPath + "/" + data);
                    }

                    FileUtil.CopyFileOrDirectory(Application.dataPath + $"/Treeplla/IosAppName/{data}/InfoPlist.strings", buildPath + "/" + data + "/InfoPlist.strings");
                    folders.Add(data, "./");
                }

                foreach(var folder in folders)
                {
                    string guid = project.AddFolderReference(folder.Value + folder.Key, folder.Key, PBXSourceTree.Source);
                    project.AddFileToBuild(targetGuid, guid);
                }
            }
            

            project.WriteToFile (projectPath);

            // get entitlements path
            string[] idArray = Application.identifier.Split('.');
            var entitlementsPath = $"Unity-iPhone/{idArray[idArray.Length - 1]}.entitlements";
    
            // create capabilities manager
            var capManager = new ProjectCapabilityManager(projectPath, entitlementsPath, null, targetGuid);
    
            // Add necessary capabilities
            capManager.AddPushNotifications(true);
    
            // Write to file
            capManager.WriteToFile();
        }

        private static string GetMaxLocalFilePath(string buildPath, string localeCode)
        {
            var resourcesDirectoryPath = Path.Combine(buildPath, AppLovinMaxResourcesDirectoryName);
            var localeSpecificDirectoryName = localeCode + ".lproj";
            var localeSpecificDirectoryPath = Path.Combine(resourcesDirectoryPath, localeSpecificDirectoryName);
            return Path.Combine(localeSpecificDirectoryPath, "InfoPlist.strings");
        }
    }
}

#endif