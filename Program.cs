using System;
using System.IO;

namespace CppParser_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("Error, pass the source root as 1st parameter.");
                return;
            }

            DirectoryInfo runtime = new DirectoryInfo(Path.Combine(args[0], "Runtime"));
            DirectoryInfo editor = new DirectoryInfo(Path.Combine(args[0], "Editor"));
            DirectoryInfo developer = new DirectoryInfo(Path.Combine(args[0], "Developer"));

            var compilation = CppAst.CppParser.ParseFile(File.ReadAllText(@"C:\Users\famas\app\UE_4.26\Engine\Source\Runtime\Engine\Classes\AI\AISystemBase.h"), GetParserOptions());

            Console.ReadLine();
        }

        static CppAst.CppParserOptions GetParserOptions()
        {
            var opt = new CppAst.CppParserOptions
            {
                ParseSystemIncludes = false,
                ParseMacros = false,
                PreHeaderText = GetPreHeaderDefines()
            };
            opt.AdditionalArguments.AddRange(new string[] { "-std=c++17", "-Wno-everything" });
            return opt;
        }

        // Returns an hardcoded list of macros used by the UE that we don't need
        private static string GetPreHeaderDefines()
        {
            return @"#define UCLASS(...)
                    #define UFUNCTION(...)
                    #define UPROPERTY(...)
                    #define GENERATED_BODY(...)
                    #define ADVERTISING_API
                    #define AIMODULE_API
                    #define ALAUDIO_API
                    #define ANALYTICS_API
                    #define ANDROID_API
                    #define ANIMATIONCORE_API
                    #define ANIMGRAPHRUNTIME_API
                    #define APPFRAMEWORK_API
                    #define APPLE_API
                    #define APPLICATIONCORE_API
                    #define ASSETREGISTRY_API
                    #define AUDIOANALYZER_API
                    #define AUDIOCAPTURECORE_API
                    #define AUDIOCAPTUREIMPLEMENTATIONS_API
                    #define AUDIOEXTENSIONS_API
                    #define AUDIOMIXER_API
                    #define AUDIOMIXERCORE_API
                    #define AUDIOPLATFORMCONFIGURATION_API
                    #define AUGMENTEDREALITY_API
                    #define AUTOMATIONMESSAGES_API
                    #define AUTOMATIONWORKER_API
                    #define AVENCODER_API
                    #define AVIWRITER_API
                    #define BLUEPRINTRUNTIME_API
                    #define BUILDSETTINGS_API
                    #define CBOR_API
                    #define CEF3UTILS_API
                    #define CINEMATICCAMERA_API
                    #define CLIENTPILOT_API
                    #define CLOTHINGSYSTEMRUNTIMECOMMON_API
                    #define CLOTHINGSYSTEMRUNTIMEINTERFACE_API
                    #define CLOTHINGSYSTEMRUNTIMENV_API
                    #define COOKEDITERATIVEFILE_API
                    #define CORE_API
                    #define COREUOBJECT_API
                    #define CRASHREPORTCORE_API
                    #define CRUNCHCOMPRESSION_API
                    #define D3D12RHI_API
                    #define DATASMITH_API
                    #define DEVELOPERSETTINGS_API
                    #define EMPTYRHI_API
                    #define ENGINE_API
                    #define ENGINEMESSAGES_API
                    #define ENGINESETTINGS_API
                    #define EXPERIMENTAL_API
                    #define EXTERNALRPCREGISTRY_API
                    #define EYETRACKER_API
                    #define FOLIAGE_API
                    #define FRIENDSANDCHAT_API
                    #define GAMEMENUBUILDER_API
                    #define GAMEPLAYMEDIAENCODER_API
                    #define GAMEPLAYTAGS_API
                    #define GAMEPLAYTASKS_API
                    #define HARDWARESURVEY_API
                    #define HEADMOUNTEDDISPLAY_API
                    #define IESFILE_API
                    #define IMAGECORE_API
                    #define IMAGEWRAPPER_API
                    #define IMAGEWRITEQUEUE_API
                    #define INPUTCORE_API
                    #define INPUTDEVICE_API
                    #define INSTALLBUNDLEMANAGER_API
                    #define IOS_API
                    #define IPC_API
                    #define JSON_API
                    #define JSONUTILITIES_API
                    #define LANDSCAPE_API
                    #define LAUNCH_API
                    #define LEVELSEQUENCE_API
                    #define LINUX_API
                    #define LIVELINKINTERFACE_API
                    #define LIVELINKMESSAGEBUSFRAMEWORK_API
                    #define LUMIN_API
                    #define MAC_API
                    #define MATERIALSHADERQUALITYSETTINGS_API
                    #define MEDIA_API
                    #define MEDIAASSETS_API
                    #define MEDIAINFO_API
                    #define MEDIAUTILS_API
                    #define MESHDESCRIPTION_API
                    #define MESHUTILITIESCOMMON_API
                    #define MESSAGING_API
                    #define MESSAGINGCOMMON_API
                    #define MESSAGINGRPC_API
                    #define MOVIEPLAYER_API
                    #define MOVIESCENE_API
                    #define MOVIESCENECAPTURE_API
                    #define MOVIESCENETRACKS_API
                    #define MRMESH_API
                    #define NAVIGATIONSYSTEM_API
                    #define NAVMESH_API
                    #define NET_API
                    #define NETWORKFILE_API
                    #define NETWORKFILESYSTEM_API
                    #define NETWORKING_API
                    #define NETWORKREPLAYSTREAMING_API
                    #define NONREALTIMEAUDIORENDERER_API
                    #define NULLDRV_API
                    #define NULLINSTALLBUNDLEMANAGER_API
                    #define ONLINE_API
                    #define OPENGLDRV_API
                    #define OVERLAY_API
                    #define PACKETHANDLERS_API
                    #define PAKFILE_API
                    #define PERFCOUNTERS_API
                    #define PHYSICSCORE_API
                    #define PHYSXCOOKING_API
                    #define PORTAL_API
                    #define PRELOADSCREEN_API
                    #define PROJECTS_API
                    #define PROPERTYACCESS_API
                    #define PROPERTYPATH_API
                    #define RAWMESH_API
                    #define REMOTEIMPORTMESSAGING_API
                    #define RENDERCORE_API
                    #define RENDERER_API
                    #define RHI_API
                    #define RIGVM_API
                    #define RSA_API
                    #define RUNTIMEASSETCACHE_API
                    #define SANDBOXFILE_API
                    #define SERIALIZATION_API
                    #define SESSIONMESSAGES_API
                    #define SESSIONSERVICES_API
                    #define SIGNALPROCESSING_API
                    #define SLATE_API
                    #define SLATECORE_API
                    #define SLATENULLRENDERER_API
                    #define SLATERHIRENDERER_API
                    #define SOCKETS_API
                    #define SOUNDFIELDRENDERING_API
                    #define STATICMESHDESCRIPTION_API
                    #define STREAMINGFILE_API
                    #define STREAMINGPAUSERENDERING_API
                    #define SYNTHBENCHMARK_API
                    #define TIMEMANAGEMENT_API
                    #define TOOLBOX_API
                    #define TRACELOG_API
                    #define UE4GAME_API
                    #define UMG_API
                    #define UNIX_API
                    #define UNREALAUDIO_API
                    #define VECTORVM_API
                    #define VIRTUALPRODUCTION_API
                    #define VULKANRHI_API
                    #define WEBBROWSER_API
                    #define WEBBROWSERTEXTURE_API
                    #define WIDGETCAROUSEL_API
                    #define WINDOWS_API
                    #define XMLPARSER_API";
        }
    }
}
