using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_h_encore {
    public static class Language {

        public static Dictionary<string, Dictionary<string, string>> Languages = new Dictionary<string, Dictionary<string, string>> {
            { "English",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Choose Language:" },
                { "lbl_VersionText", "auto h-encore version " },
                { "lbl_Issues", "Issue Tracker" },
                { "lbl_ConnectionMethod", "How do you plan to connect your PS Vita to transfer h-encore?" },
                { "lbl_UnplugVita", "If your Vita is plugged in, unplug it, then click next." },
                { "lbl_InstallingUSB", "Installing USB driver, please wait..." },

                { "status_NoFile", "No file selected, will download." },
                { "status_Invalid", "File path is invalid." },
                { "status_Valid", "File selected and hash matches, will import." },
                { "status_BadHash", "File selected but hash does not match, will download." },
                { "status_Override", "File selected but hash does not match. Hash override enabled, will import." },
                { "status_Calculating", "Calculating file hash..." },

                { "txtblock_BeforeRunning", "The application will automatically download QCMA if it is not installed. It will also automatically launch and manage it. That means:\r\n    If QCMA is not installed:\r\n        QCMA will be downloaded for local use by this program.\r\n        A USB driver will be installed if you choose to transfer via USB\r\n    If QCMA is installed:\r\n        Your existing QCMA installation will be used.\r\n        No new USB drivers will be installed, and your configuration will not be overwritten.\r\n\r\nBasically, you no longer need to interact with QCMA unless there are problems. If you have issues, please submit a report on the issue tracker."},
                { "txtblock_Import", "If you've already downloaded some or all of the necessary files, and don't want the application to redownload them, you can select the files here for the program to import." },
                { "txtblock_USBInstructions", "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (and do the steps above again).\r\n\r\nIf it still doesn't work, you may need to install QCMA manually and pick a driver other than libusbk." },
                { "txtblock_WifiInstructions", "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB." },

                { "btn_Import", "I've already downloaded some or all of the files and would like to use them rather than redownload them" },
                { "btn_Ok", "OK" },
                { "btn_Close", "Close" },
                { "btn_Start", "Start" },
                { "btn_Done", "Done" },
                { "btn_Browse", "Browse" },
                { "btn_Next", "Next" },
                { "btn_USB", "USB" },
                { "btn_Wifi", "WiFi (Firmware 3.68 ONLY)" },
                
                { "cbx_Trim", "Trim excess content from bitter smile demo (reduces h-encore app size from ~240MB to ~13MB)" },
                { "cbx_DeleteExisting", "Delete existing files (do this if something went wrong before)" },
                { "cbx_OverrideHashes", "Ignore Mismatch File Hashes" },

                { "browse_Generic", "Browse for " },

                { "info_Finish",  "To finish your h-encore installation:\r\n"
                        + "1. Connect your PS Vita to your PC using Content Manager like you did before (if it isn't still connected)"
                        + "     If it says you need to update your firmware, turn off Wifi on your Vita and restart the Vita\r\n"
                        + "2. In Content Manager, choose PC -> PS Vita System\r\n"
                        + "3. Select Applications\r\n"
                        + "4. Select PS Vita\r\n"
                        + "5. Select h-encore and hit Copy\r\n"
                        + "6. Run the h-encore app from the Live Area\r\n"
                        + "     If it crashes the first time, try restarting your Vita and launching the bubble again\r\n\r\n"
                        + "Done!"},

                { "warn_HashCompat", "Compatibility is not guranteed when using versions of files this application was not designed for. Continue anyways?" },
                { "warn_DeleteExistingBittersmile", "You must remove the existing bittersmile backup from your QCMA directory. If you want to keep it, move it now. Delete?" },

                { "error_WebException", "Failed to download file. Please check your internet connection." },
                { "error_Unknown", "Something went wrong: {0}" },
                { "error_DirectoryNotFoundException", "A directory that was created seem to have disappeared (did they get deleted?) OR a directory failed to extract earlier OR you are using an unsupported file import." },
                { "error_UnauthorizedAccessException", "The application doesn't have write access to the directory it was installed in. Try rerunning the application as administrator." },
                { "error_FileNotFoundException",  "A file that was created seem to have disappeared (did they get deleted?) OR a file failed to extract earlier OR you are using an unsupported file import."},
                { "error_InvalidOperationException",  "A download is corrupt. Make sure your network is stable."},
                { "error_TargetInvocationException", "Failed to create MD5 calculator." },
                { "error_Template", "Error {0} occurred.\r\n\r\n{1}\r\n\r\nPlease retry the process. If you can't solve the issue, please create an issue on the issue tracker with this error code." },
                { "error_Redownload",  "Error 1001-0105\r\n\r\nFailed to download file {0}\r\n\r\nMake sure your internet is connected and/or retry. If it still doesn't work, create an issue on the Github issue tracker."},

                { "log_SearchingForQCMA", "Searching for QCMA..." },
                { "log_FoundQCMA", "Found QCMA." },
                { "log_QCMANotFound", "QCMA not found, will download." },
                { "log_KillingQCMA", "Killing any running QCMA processes..." },
                { "log_QCMARegistry", "Importing QCMA registry information..." },
                { "log_ScrubAID", "Scrubbing AID value" },
                { "log_Prompt", "Prompting user for information..." },
                { "log_Done", "        Done!" },
                { "log_WipeFiles", "Deleting old files..." },
                { "log_Import", "File import for file {0} valid." },
                { "log_DownloadValid", "File {0} already downloaded and valid, won't redownload." },
                { "log_DownloadInvalid", "File {0} already downloaded but hash doesn't match, will redownload." },
                { "log_NotDownloaded", "File {0} not downloaded or imported, will download." },
                { "log_WorkingDirs", "Generating working directories..." },
                { "log_CorrectLocation", "File {0} in correct location, skipping." },
                { "log_Importing", "Importing {0}" },
                { "log_Downloading", "Downloading {0}" },
                { "log_Extracting", "Extracting {0}" },
                { "log_ExtractingPKG", "Extracting bittersmile demo with pkg2zip..." },
                { "log_Trimming", "Trimming excess content from bittersmile demo..." },
                { "log_MoveToHencore", "Moving {0} to h-encore working directory..." },
                { "log_MoveLicense", "Moving license file..." },
                { "log_GetCMA", "Getting CMA encryption key using AID {0}" },
                { "log_GotCMA", "Got CMA encryption key {0}" },
                { "log_Packaging", "Packaging h-encore {0} using psvimgtools..." },
                { "log_MoveToQCMA", "Moving h-encore files to QCMA APP directory...\r\n" },
                { "log_Finished", "auto h-encore Finished!!\r\n" },

                { "title_Main", "auto h-encore" },
                { "title_Import", "Import Existing Files" },
                { "title_Warning", "Warning" },
                { "title_Error", "Error" }
            } },
            { "简体中文",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "选择语言:" },
                { "lbl_VersionText", "自动 h-encore 版本 " },
                { "lbl_Issues", "问题追踪器" },
                { "lbl_ConnectionMethod", "How do you plan to connect your PS Vita to transfer h-encore?" },
                { "lbl_UnplugVita", "If your Vita is plugged in, unplug it, then click next." },
                { "lbl_InstallingUSB", "Installing USB driver, please wait..." },

                { "status_NoFile", "未选中任何文件, 将开始下载." },
                { "status_Invalid", "文件目录无效." },
                { "status_Valid", "已选择文件且校验通过, 即将导入." },
                { "status_BadHash", "已选择文件但校验未通过, 将开始下载." },
                { "status_Override", "已选择文件且校验未通过. 已忽略不匹配校验信息, 即将导入." },
                { "status_Calculating", "校验中..." },

                { "txtblock_BeforeRunning", "The application will automatically download QCMA if it is not installed. It will also automatically launch and manage it. That means:\r\n    If QCMA is not installed:\r\n        QCMA will be downloaded for local use by this program.\r\n        A USB driver will be installed if you choose to transfer via USB\r\n    If QCMA is installed:\r\n        Your existing QCMA installation will be used.\r\n        No new USB drivers will be installed, and your configuration will not be overwritten.\r\n\r\nBasically, you no longer need to interact with QCMA unless there are problems. If you have issues, please submit a report on the issue tracker."},                { "txtblock_Import", "如果您已经下载了部分或全部必要文件, 并且不希望本程序重新下载它们, 则可以在此处选择要导入程序的文件." },
                { "txtblock_USBInstructions", "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (and do the steps above again).\r\n\r\nIf it still doesn't work, you may need to install QCMA manually and pick a driver other than libusbk." },
                { "txtblock_WifiInstructions", "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB." },

                { "btn_Import", "我已经下载了一部分或者全部必要的文件, 我想使用它们, 不要重新下载" },
                { "btn_Ok", "确定" },
                { "btn_Close", "关闭" },
                { "btn_Start", "启动" },
                { "btn_Done", "完成" },
                { "btn_Browse", "浏览" },
                { "btn_Next", "Next" },
                { "btn_USB", "USB" },
                { "btn_Wifi", "WiFi (Firmware 3.68 ONLY)" },

                { "cbx_Trim", "删减 bitter smile demo 的多余内容 (将 h-encore app 大小 从 240MB 减小到 13MB)" },
                { "cbx_DeleteExisting", "删除已存在的文件 (如果之前的操作出错，请勾选它)" },
                { "cbx_OverrideHashes", "忽略不匹配的文件校验信息" },

                { "browse_QCMA", "请选择你的 PS Vita/APP 目录 (可以在 QCMA 设置界面找到)" },
                { "browse_Generic", "Browse for " },

                { "info_Finish",  "完成 h-encore 安装:\r\n"
                        + "1. Connect your PS Vita to your PC using Content Manager like you did before (if it isn't still connected)"
                        + "     如果Vita提示你需要更新系统, 关闭无线网络后重启 Vita\r\n"
                        + "2. 在 内容管理 程序界面, 选择 电脑 -> PS Vita\r\n"
                        + "3. 选择 应用程序\r\n"
                        + "4. 选择 PS Vita\r\n"
                        + "5. 选择 h-encore 并点击 复制\r\n"
                        + "6. 启动主界面的 h-encore 程序\r\n"
                        + "     如果初次启动崩溃, 尝试重启Vita后再运行该气泡\r\n\r\n"
                        + "完成!"},

                { "warn_HashCompat", "使用不匹配的文件版本无法保证兼容性. 你确定要继续么?" },
                { "warn_DeleteExistingBittersmile", "你必须移除 QCMA 备份目录内已存在的 bittersmile 备份. 如果你想保留它,请立刻手动转移. 是否删除?" },

                { "error_WebException", "下载文件失败. 请检查网络连接." },
                { "error_Unknown", "出现错误: {0}" },
                { "error_DirectoryNotFoundException", "创建的目录丢失 (被删除了?) 或者上一步的目录未能提取, 或者您正在导入不受支持的文件." },
                { "error_UnauthorizedAccessException", "本程序没有对其安装目录的写入权限. 请尝试以管理员身份重新运行本程序." },
                { "error_FileNotFoundException",  "创建的文件丢失 (被删除了?) 或者上一步文件提取失败,或者您正在导入不受支持的文件."},
                { "error_InvalidOperationException",  "下载内容已损坏. 确保您的网络稳定."},
                { "error_TargetInvocationException", "MD5 校验失败." },
                { "error_Template", "发生 {0} 错误.\r\n\r\n{1}\r\n\r\n请重试该操作. 如果您无法解决问题, 请使用此错误代码在问题追踪器上创建报告." },
                { "error_Redownload",  "错误 1001-0105\r\n\r\n下载 {0} 文件失败\r\n\r\n确保您已联网并重试. 如果软件仍然不起作用，请在Github问题追踪器上创建一个报告."},

                { "log_SearchingForQCMA", "Searching for QCMA..." },
                { "log_FoundQCMA", "Found QCMA." },
                { "log_QCMANotFound", "QCMA not found, will download." },
                { "log_KillingQCMA", "Killing any running QCMA processes..." },
                { "log_QCMARegistry", "Importing QCMA registry information..." },
                { "log_ScrubAID", "Scrubbing AID value" },
                { "log_Prompt", "Prompting user for information..." },
                { "log_Done", "        完成!" },
                { "log_WipeFiles", "删除旧文件..." },
                { "log_Import", "导入的文件 {0} 有效." },
                { "log_DownloadValid", "文件 {0} 已下载并且有效, 不再重新下载." },
                { "log_DownloadInvalid", "文件 {0} 已下载但 hash 不匹配, 将要重新下载." },
                { "log_NotDownloaded", "文件 {0} 未下载或者导入, 将开始下载." },
                { "log_WorkingDirs", "生成工作目录..." },
                { "log_CorrectLocation", "文件 {0} 在正确的位置, 跳过." },
                { "log_Importing", "正在导入 {0}" },
                { "log_Downloading", "正在下载 {0}" },
                { "log_Extracting", "正在解压 {0}" },
                { "log_ExtractingPKG", "正在用 pkg2zip 解包 bittersmile demo..." },
                { "log_Trimming", "正在删减 bitter smile demo 的多余内容..." },
                { "log_MoveToHencore", "正在移动 {0} 到 h-encore 的工作目录..." },
                { "log_MoveLicense", "正在移动许可文件..." },
                { "log_GetCMA", "正在利用 AID 获取 CMA 加密密钥 {0}" },
                { "log_GotCMA", "已得到 CMA 加密密钥 {0}" },
                { "log_Packaging", "正在利用 psvimgtools {0} 打包 h-encore..." },
                { "log_MoveToQCMA", "正在移动 h-encore 文件到 QCMA APP 备份目录...\r\n" },
                { "log_Finished", "自动 h-encore 完成!!\r\n" },

                { "title_Main", "自动 h-encore" },
                { "title_Import", "导入已下载的文件" },
                { "title_Warning", "警告" },
                { "title_Error", "错误" }
            } },
            { "Español-ES",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Elegir idioma:" },
                { "lbl_VersionText", "Versión de auto H-encore " },
                { "lbl_Issues", "Seguimiento de incidencias" },
                { "lbl_ConnectionMethod", "How do you plan to connect your PS Vita to transfer h-encore?" },
                { "lbl_UnplugVita", "If your Vita is plugged in, unplug it, then click next." },
                { "lbl_InstallingUSB", "Installing USB driver, please wait..." },

                { "status_NoFile", "Ningún archivo seleccionado, se descargará el archivo." },
                { "status_Invalid", "Ruta no válida." },
                { "status_Valid", "El archivo y el hash seleccionado son correctos, se importarán." },
                { "status_BadHash", "El hash no concuerda con el archivo, se descargará." },
                { "status_Override", "El hash no concuerda con el archivo, habilitado deshabilitar hash, se importará." },
                { "status_Calculating", "Calculando archivo hash..." },

                { "txtblock_BeforeRunning", "The application will automatically download QCMA if it is not installed. It will also automatically launch and manage it. That means:\r\n    If QCMA is not installed:\r\n        QCMA will be downloaded for local use by this program.\r\n        A USB driver will be installed if you choose to transfer via USB\r\n    If QCMA is installed:\r\n        Your existing QCMA installation will be used.\r\n        No new USB drivers will be installed, and your configuration will not be overwritten.\r\n\r\nBasically, you no longer need to interact with QCMA unless there are problems. If you have issues, please submit a report on the issue tracker."},                { "txtblock_Import", "如果您已经下载了部分或全部必要文件, 并且不希望本程序重新下载它们, 则可以在此处选择要导入程序的文件." },
                { "txtblock_Import", "Si has descargado todos o algunos de los archivos, y no quieres que la aplicación los vuelva a descargar, aquí puedes seleccionar los archivos para que el programa los importe." },
                { "txtblock_USBInstructions", "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (and do the steps above again).\r\n\r\nIf it still doesn't work, you may need to install QCMA manually and pick a driver other than libusbk." },
                { "txtblock_WifiInstructions", "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB." },

                { "btn_Import", "Ya se descargaron todos o parte de los archivos y puedes usarlos o volverlos a descargar." },
                { "btn_Ok", "OK" },
                { "btn_Close", "Cerrar" },
                { "btn_Start", "Empezar" },
                { "btn_Done", "Hecho" },
                { "btn_Browse", "Navegar" },
                { "btn_Next", "Next" },
                { "btn_USB", "USB" },
                { "btn_Wifi", "WiFi (Firmware 3.68 ONLY)" },

                { "cbx_Trim", "Eliminar contenido sobrante de la demo bitter smile (reduce el tamaño de app de H-encore de ~240MB a ~13MB)." },
                { "cbx_DeleteExisting", "Borrar archivos existentes (haz esto si ha ocurrido algún error en el proceso)." },
                { "cbx_OverrideHashes", "Ignorar los Hashes de los archivos." },

                { "browse_QCMA", "Localiza tu directorio PS Vita de QCMA (lo encontrarás en las opciones de QCMA bajo Aplicación / Copias de Seguridad)." },
                { "browse_Generic", "Buscar " },

                { "info_Finish",  "Para finalizar la instalación de H-encore:\r\n"
                        + "1. Connect your PS Vita to your PC using Content Manager like you did before (if it isn't still connected)"
                        + "     (Si pone que tienes que actualizar el firmware, apaga el wifi en tu PS Vita y reiniciala.)\r\n"
                        + "2. En Gestor Contenido, elige PC -> PS Vita.\r\n"
                        + "3. Selecciona Aplicaciones.\r\n"
                        + "4. Selecciona PS Vita.\r\n"
                        + "5. Selecciona H-encore y pulsa en Copiar.\r\n"
                        + "6. Ejecuta la aplicación H-encore desde el Live Area.\r\n"
                        + "     Si no funciona la primera vez, reiniciar tu PS Vita y ejecútalo de nuevo.\r\n\r\n"
                        + "¡Acabado!"},

                { "warn_HashCompat", "La compatibilidad no está garantizada usando versiones de los archivos no diseñados para esta aplicación. ¿Continuar de todas formas?" },
                { "warn_DeleteExistingBittersmile", "Debes borrar la copia de seguridad de bitter smile en el directorio de QCMA. Si no quieres borrarlo, muévelo a otro directorio. ¿Borrar?" },

                { "error_WebException", "Fallo al descargar el archivo. Por favor, comprueba tu conexión a internet." },
                { "error_Unknown", "Algo ha fallado: {0}." },
                { "error_DirectoryNotFoundException", "Un directorio creado ha desaparecido (¿Ha sido borrado?) O un directorio falló al extraerse O estás importando un fichero no soportado." },
                { "error_UnauthorizedAccessException", "La aplicación no tiene permiso de escritura en el directorio en el que está instalado. Intenta ejecutar la aplicación como Administrador." },
                { "error_FileNotFoundException",  "Un archivo creado ha desaparecido (¿Ha sido borrado?) O un archivo falló al extraerse O estás importando un fichero no soportado."},
                { "error_InvalidOperationException",  "Hay una descarga corrupta. Asegúrate que tu conexión de red es estable."},
                { "error_TargetInvocationException", "Fallo al crear calculadora de MD5." },
                { "error_Template", "Error {0}.\r\n\r\n{1}\r\n\r\nPor favor intenta de nuevo el proceso. Si no puedes solucionar esta incidencia, por favor crea una incidencia en el seguimiento de incidencias." },
                { "error_Redownload",  "Error 1001-0105\r\n\r\nFallo al descargar el archivo {0}\r\n\r\nAsegúrate que tienes conexión a internet y/o inténtalo de nuevo. Si sigue sin funcionar, crea una incidencia en el seguimiento de incidencias de Github."},

                { "log_SearchingForQCMA", "Searching for QCMA..." },
                { "log_FoundQCMA", "Found QCMA." },
                { "log_QCMANotFound", "QCMA not found, will download." },
                { "log_KillingQCMA", "Killing any running QCMA processes..." },
                { "log_QCMARegistry", "Importing QCMA registry information..." },
                { "log_ScrubAID", "Scrubbing AID value" },
                { "log_Prompt", "Prompting user for information..." },
                { "log_Done", "        ¡Hecho!" },
                { "log_WipeFiles", "Borrando archivos antigüos..." },
                { "log_Import", "Importar archivo {0} válido." },
                { "log_DownloadValid", "El archivo {0} ya ha sido descargado y validado, no se descargará." },
                { "log_DownloadInvalid", "El archivo {0} ya ha sido descargado pero el hash no concuerda, se volverá a descargar." },
                { "log_NotDownloaded", "El archivo {0} no se ha descargado o importado, se descargará." },
                { "log_WorkingDirs", "Generando directorios válidos..." },
                { "log_CorrectLocation", "El archivo {0} está en la localización correcta, se omitirá." },
                { "log_Importing", "Importando {0}." },
                { "log_Downloading", "Descargando {0}." },
                { "log_Extracting", "Extrayendo {0}." },
                { "log_ExtractingPKG", "Extrayendo demo de bitter smile con pkg2zip..." },
                { "log_Trimming", "Eliminando exceso de datos de la demo de bitter smile..." },
                { "log_MoveToHencore", "Moviendo {0} a directorio válido de H-encore..." },
                { "log_MoveLicense", "Moviendo archivo de licencia..." },
                { "log_GetCMA", "Consiguiendo clave de encripción CMA usando AID {0}..." },
                { "log_GotCMA", "Consiguiendo clave de encripción CMA {0}..." },
                { "log_Packaging", "Empaquetando H-encore {0} usando psvimgtools..." },
                { "log_MoveToQCMA", "Moviendo archivos de H-encore al directorio APP de QCMA...\r\n" },
                { "log_Finished", "¡¡Auto H-encore finalizado!!\r\n" },

                {"title_Main", "auto H-encore" },
                {"title_Import", "Importar archivos"},
                {"title_Warning", "Advertencia"},
                {"tittle_Error", "Error"},
            } },
            { "Italiano",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Scegli la lingua:" },
                { "lbl_HowToAID", "Come ottengo queste informazioni?" },
                { "lbl_VersionText", "versione auto h-encore " },
                { "lbl_Issues", "Tracker dei problemi" },
                { "lbl_ConnectionMethod", "How do you plan to connect your PS Vita to transfer h-encore?" },
                { "lbl_UnplugVita", "If your Vita is plugged in, unplug it, then click next." },
                { "lbl_InstallingUSB", "Installing USB driver, please wait..." },

                { "status_NoFile", "Nessun file selezionato, verrà scaricato." },
                { "status_Invalid", "Il percorso del file non è valido." },
                { "status_Valid", "Il file selezionato e le corrispondenze hash verranno importate." },
                { "status_BadHash", "Il file selezionato, ma l'hash non corrisponde, verrà scaricato." },
                { "status_Override", "File selezionato ma l'hash non corrisponde. Hash override abilitato, verrà importato." },
                { "status_Calculating", "Calcolo dell'hash del file..." },

                { "txtblock_BeforeRunning", "The application will automatically download QCMA if it is not installed. It will also automatically launch and manage it. That means:\r\n    If QCMA is not installed:\r\n        QCMA will be downloaded for local use by this program.\r\n        A USB driver will be installed if you choose to transfer via USB\r\n    If QCMA is installed:\r\n        Your existing QCMA installation will be used.\r\n        No new USB drivers will be installed, and your configuration will not be overwritten.\r\n\r\nBasically, you no longer need to interact with QCMA unless there are problems. If you have issues, please submit a report on the issue tracker."},                { "txtblock_Import", "如果您已经下载了部分或全部必要文件, 并且不希望本程序重新下载它们, 则可以在此处选择要导入程序的文件." },
                { "txtblock_Import", "Se hai già scaricato alcuni o tutti i file necessari, e non vuoi che l'applicazione li scarichi di nuovo, qui puoi selezionare i file da importare per il programma." },
                { "txtblock_USBInstructions", "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (and do the steps above again).\r\n\r\nIf it still doesn't work, you may need to install QCMA manually and pick a driver other than libusbk." },
                { "txtblock_WifiInstructions", "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB." },

                { "btn_Import", "Ho già scaricato alcuni o tutti i file e vorrei utilizzarli invece di riscaricarli" },
                { "btn_Ok", "OK" },
                { "btn_Close", "Chiudi" },
                { "btn_Start", "Start" },
                { "btn_Done", "Fatto" },
                { "btn_Browse", "Sfoglia" },
                { "btn_Next", "Next" },
                { "btn_USB", "USB" },
                { "btn_Wifi", "WiFi (Firmware 3.68 ONLY)" },

                { "cbx_Trim", "Ritaglia il contenuto in eccesso dalla demo bitter smile (riduce le dimensioni delle app h-encore da ~ 240 MB a ~ 13 MB)" },
                { "cbx_DeleteExisting", "Elimina i file esistenti (fai questo se qualcosa è andato storto prima)" },
                { "cbx_OverrideHashes", "Ignora hash di file non corrispondenti" },

                { "browse_QCMA", "Individua la directory QCMA PS Vita (trovala nelle impostazioni QCMA in Applicazioni / Backup)" },
                { "browse_Generic", "Sfoglia per " },

                { "info_Finish",  "Per finire l'installazione di h-encore:\r\n"
                         + "1. Connect your PS Vita to your PC using Content Manager like you did before (if it isn't still connected)\r\n"
                         + "     Se dice che è necessario aggiornare il firmware, disattivare la Wifi su PSVita e riavviare la PSVita\r\n"
                         + "2. In Gestione Contenuto, scegli PC -> Sistema PS Vita\r\n"
                         + "3. Seleziona Applicazioni\r\n"
                         + "4. Seleziona PS Vita\r\n"
                         + "5. Seleziona h-encore e premere su Copia\r\n"
                         + "6. Eseguire l'applicazione di h-encore dal Live Area\r\n"
                         + "     Se si blocca per la prima volta, prova a riavviare la PSVita e a lanciare nuovamente la bolla\r\n\r\n"
                         + "Fatto!"},

                { "warn_HashCompat", "La compatibilità non è garantita quando si utilizzano versioni di file per cui questa applicazione non è stata progettata. Continuare comunque?" },
                { "warn_DeleteExistingBittersmile", "È necessario rimuovere il backup bittersmile esistente dalla directory QCMA. Se vuoi tenerlo, spostalo ora. Elimina?" },

                { "error_WebException", "Impossibile scaricare il file. Per favore controlla la tua connessione Internet." },
                { "error_Unknown", "Qualcosa è andato storto: {0}" },
                { "error_DirectoryNotFoundException", "Una cartella che è stata creata sembra essere scomparsa (è stata eliminata?) OPPURE una cartella non è stata in grado di estrarre prima O si sta utilizzando un'importazione di file non supportata." },
                { "error_UnauthorizedAccessException", "L'applicazione non ha accesso in scrittura nella cartella in cui è stata installata. Prova a rieseguire l'applicazione come amministratore." },
                { "error_FileNotFoundException",  "Un file che è stato creato sembra essere scomparso (sono stati cancellati?) OPPURE un file non è stato in grado di estrarre prima O si sta utilizzando un'importazione di file non supportata."},
                { "error_InvalidOperationException",  "Un download è corrotto. Assicurati che la tua rete sia stabile."},
                { "error_TargetInvocationException", "Impossibile creare il calcolatore MD5." },
                { "error_Template", "Errore {0} riscontrato.\r\n\r\n{1}\r\n\r\nSi prega di riprovare il processo. Se non riesci a risolvere il problema, crea un problema sul tracker dei problemi con questo codice di errore." },
                { "error_Redownload",  "Errore 1001-0105\r\n\r\nImpossibile scaricare il file {0}\r\n\r\nAssicurati che la tua connessione a Internet sia connessa e / o riprova. Se continua a non funzionare, crea un problema sul tracker dei problemi di Github."},

                { "log_SearchingForQCMA", "Searching for QCMA..." },
                { "log_FoundQCMA", "Found QCMA." },
                { "log_QCMANotFound", "QCMA not found, will download." },
                { "log_KillingQCMA", "Killing any running QCMA processes..." },
                { "log_QCMARegistry", "Importing QCMA registry information..." },
                { "log_ScrubAID", "Scrubbing AID value" },
                { "log_Prompt", "Prompting user for information..." },
                { "log_Done", "        Fatto!" },
                { "log_WipeFiles", "Eliminazione dei vecchi file..." },
                { "log_Import", "Importazione dei file per il file {0} valido." },
                { "log_DownloadValid", "File {0} già scaricato e valido, non verrà riscaricato." },
                { "log_DownloadInvalid", "File {0} già scaricato ma l'hash non corrisponde, verrà riscaricato." },
                { "log_NotDownloaded", "File {0} non scaricato o importato, verrà scaricato." },
                { "log_WorkingDirs", "Generazione delle cartelle di lavoro..." },
                { "log_CorrectLocation", "File {0} nella posizione corretta, saltando." },
                { "log_Importing", "Importazione di {0}" },
                { "log_Downloading", "Scaricamento di {0}" },
                { "log_Extracting", "Estrazione di {0}" },
                { "log_ExtractingPKG", "Estrazione della demo di bittersmile con pkg2zip..." },
                { "log_Trimming", "Ritaglio dei contenuti in eccesso dalla demo di bittersmile..." },
                { "log_MoveToHencore", "Spostamento di {0} nella cartella di lavoro di h-encore..." },
                { "log_MoveLicense", "Spostamento del file di licenza..." },
                { "log_GetCMA", "Ottenimento della chiave di crittografia CMA utilizzando l'AID{0}" },
                { "log_GotCMA", "Ho la chiave di crittografia CMA {0}" },
                { "log_Packaging", "Rimpacchettamento di h-encore {0} utilizzando psvimgtools..." },
                { "log_MoveToQCMA", "Spostamento dei file h-encore nella cartella APP del QCMA...\r\n" },
                { "log_Finished", "Processo finito.auto h-encore creato con successo!!\r\n" },

                { "title_Main", "auto h-encore" },
                { "title_Import", "Importa file esistenti" },
                { "title_Warning", "Attenzione" },
                { "title_Error", "Errore" }
            } },
            { "Русский",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Выберите язык:" },
                { "lbl_VersionText", "Версия auto h-encore " },
                { "lbl_Issues", "Issue-трекер" },
                { "lbl_ConnectionMethod", "How do you plan to connect your PS Vita to transfer h-encore?" },
                { "lbl_UnplugVita", "If your Vita is plugged in, unplug it, then click next." },
                { "lbl_InstallingUSB", "Installing USB driver, please wait..." },

                { "status_NoFile", "Файл не выбран и он будет загружен." },
                { "status_Invalid", "Неверный путь к файлу." },
                { "status_Valid", "Файл выбран и проверка хэша прошла успешно." },
                { "status_BadHash", "Файл выбран, но хэш не прошел проверку, он будет переустановлен." },
                { "status_Override", "Файл выбран, но хэш не прошел проверку. Перерасчет хэша запущен и он будет импортирован." },
                { "status_Calculating", "Расчет хэша файла..." },

                { "txtblock_BeforeRunning", "The application will automatically download QCMA if it is not installed. It will also automatically launch and manage it. That means:\r\n    If QCMA is not installed:\r\n        QCMA will be downloaded for local use by this program.\r\n        A USB driver will be installed if you choose to transfer via USB\r\n    If QCMA is installed:\r\n        Your existing QCMA installation will be used.\r\n        No new USB drivers will be installed, and your configuration will not be overwritten.\r\n\r\nBasically, you no longer need to interact with QCMA unless there are problems. If you have issues, please submit a report on the issue tracker."},                { "txtblock_Import", "如果您已经下载了部分或全部必要文件, 并且不希望本程序重新下载它们, 则可以在此处选择要导入程序的文件." },
                { "txtblock_Import", "Если вы заранее установили все нужные файлы и не хотите чтоб программа снова их установила, то здесь вы можете выбрать уже имеющиеся файлы." },
                { "txtblock_USBInstructions", "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (and do the steps above again).\r\n\r\nIf it still doesn't work, you may need to install QCMA manually and pick a driver other than libusbk." },
                { "txtblock_WifiInstructions", "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB." },

                { "btn_Import", "Я уже загрузил некоторые или все файлы и хотел бы использовать их, а не загружать их заново." },
                { "btn_Ok", "OK" },
                { "btn_Close", "Закрыть" },
                { "btn_Start", "Начать" },
                { "btn_Done", "Готово" },
                { "btn_Browse", "Обзор" },
                { "btn_Next", "Next" },
                { "btn_USB", "USB" },
                { "btn_Wifi", "WiFi (Firmware 3.68 ONLY)" },

                { "cbx_Trim", "Обрезать лишний контент из bittersmile demo (размер h-encore уменьшается с ~240MБ до ~13MБ)" },
                { "cbx_DeleteExisting", "Удаление лишних файлов (сделайте это, если ранее что-то пошло не так)" },
                { "cbx_OverrideHashes", "Игнорировать несоответствие хэша" },

                { "browse_QCMA", "Откройте директорию QCMA PS Vita (найдите её в настройках QCMA (Applications / Backups)" },
                { "browse_Generic", "Обзор " },

                { "info_Finish",  "Чтобы закончить установку h-encore:\r\n"
                        + "1. Connect your PS Vita to your PC using Content Manager like you did before (if it isn't still connected)\r\n"
                        + "     Если требуется обновить прошивку, то выключите Wi-Fi на Vita и перезагрузите её\r\n"
                        + "2. В Управлении данными, нажмите Компьютер -> Система PS Vita\r\n"
                        + "3. Нажмите Приложения\r\n"
                        + "4. Нажмите PS Vita\r\n"
                        + "5. Выберите h-encore и нажмите Скопировать\r\n"
                        + "6. Запустите h-encore в LiveArea\r\n"
                        + "     Если h-encore вылетает, то перезагрузите PS Vita и попробуйте снова\r\n\r\n"
                        + "Готово!"},

                { "warn_HashCompat", "Совместимость не гарантируется при использовании версий файлов, для которых это приложение не предназначено. Все равно продолжить?" },
                { "warn_DeleteExistingBittersmile", "Вы должны удалить существущий бэкап bittersmile из вашей директории QCMA directory. Если вы хотите её оставить, то просто переместите. Удалить?" },

                { "error_WebException", "Не удалось загрузить файл, проверьте ваше соединение." },
                { "error_Unknown", "Что-то пошло не так: {0}" },
                { "error_DirectoryNotFoundException", "Созданная директория, кажется, исчезла (может, она была удалена?), ранее директорию не удалось распаковать или вы хотите импортировать неподдерживаемый файл." },
                { "error_UnauthorizedAccessException", "Программа не получила доступа к директории. Попробуйте перезапустить программу от имени администратора." },
                { "error_FileNotFoundException",  "Созданный файл, кажется, исчез (может,он был удален?), ранее файл не удалось распаковать, или вы хотите импортировать неподдерживаемый файл."},
                { "error_InvalidOperationException",  "Файл был поврежден. Убедитесь в стабильности вашего интернет соединения."},
                { "error_TargetInvocationException", "Не удалось создать MD5 калькулятор." },
                { "error_Template", "Произошла ошибка {0}.\r\n\r\n{1}\r\n\r\nПовторите процесс. Если вы не можете решить проблему, пожалуйста, создайте issue в issue-трекере с этим кодом ошибки." },
                { "error_Redownload",  "Ошибка 1001-0105\r\n\r\nНе удалось установить файл {0}\r\n\r\nПроверьте подключение к интернету и попробуйте снова. Если все в порядке, а ошибка не пропадает, то создайте issue на GitHub."},

                { "log_SearchingForQCMA", "Searching for QCMA..." },
                { "log_FoundQCMA", "Found QCMA." },
                { "log_QCMANotFound", "QCMA not found, will download." },
                { "log_KillingQCMA", "Killing any running QCMA processes..." },
                { "log_QCMARegistry", "Importing QCMA registry information..." },
                { "log_ScrubAID", "Scrubbing AID value" },
                { "log_Prompt", "Prompting user for information..." },
                { "log_Done", "        Готово!" },
                { "log_WipeFiles", "Удаление старых файлов..." },
                { "log_Import", "Импорт файла для {0} прошел успешно." },
                { "log_DownloadValid", "Файл {0} уже загружен и проверен." },
                { "log_DownloadInvalid", "Файл {0} уже загружен, но хэш не прошел проверку, он будет загружен заново." },
                { "log_NotDownloaded", "Файл {0} не загружен или не импортирован, он будет загружен заново." },
                { "log_WorkingDirs", "Генерация рабочих директорий..." },
                { "log_CorrectLocation", "Файл {0} в правильной локации." },
                { "log_Importing", "Импорт {0}" },
                { "log_Downloading", "Загрузка {0}" },
                { "log_Extracting", "Распаковка {0}" },
                { "log_ExtractingPKG", "Распаковка bittersmile demo через pkg2zip..." },
                { "log_Trimming", "Удаление лишних файлов из bittersmile demo..." },
                { "log_MoveToHencore", "Перемещение {0} в рабочую директорию h-encore..." },
                { "log_MoveLicense", "Перемещение license файла..." },
                { "log_GetCMA", "Получение шифровочного ключа CMA используя AID {0}" },
                { "log_GotCMA", "CMA получен {0}" },
                { "log_Packaging", "Упаковка h-encore {0} через psvimgtools..." },
                { "log_MoveToQCMA", "Перемещение файлов h-encore в директорию QCMA APP...\r\n" },
                { "log_Finished", "auto h-encore выполнен!!!\r\n" },

                { "title_Main", "auto h-encore" },
                { "title_Import", "Импорт существующих файлов" },
                { "title_Warning", "Внимание" },
                { "title_Error", "Ошибка" }
            } },
            { "Português-BR",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Escolha o idioma:" },
                { "lbl_VersionText", "Versão auto h-encore " },
                { "lbl_Issues", "Rastreador de Erros" },
                { "lbl_ConnectionMethod", "How do you plan to connect your PS Vita to transfer h-encore?" },
                { "lbl_UnplugVita", "If your Vita is plugged in, unplug it, then click next." },
                { "lbl_InstallingUSB", "Installing USB driver, please wait..." },

                { "status_NoFile", "Nenhum arquivo selecionado, vai baixar." },
                { "status_Invalid", "Caminho do arquivo inválido." },
                { "status_Valid", "Arquivo selecionado e hash corresponde, vai importar." },
                { "status_BadHash", "Arquivo selecionado mas hash não corresponde, vai baixar." },
                { "status_Override", "Arquivo selecionado mas hash não corresponde. Reescrita de hash habilitada, vai importar." },
                { "status_Calculating", "Calculando hash do arquivo..." },

                { "txtblock_BeforeRunning", "The application will automatically download QCMA if it is not installed. It will also automatically launch and manage it. That means:\r\n    If QCMA is not installed:\r\n        QCMA will be downloaded for local use by this program.\r\n        A USB driver will be installed if you choose to transfer via USB\r\n    If QCMA is installed:\r\n        Your existing QCMA installation will be used.\r\n        No new USB drivers will be installed, and your configuration will not be overwritten.\r\n\r\nBasically, you no longer need to interact with QCMA unless there are problems. If you have issues, please submit a report on the issue tracker."},                { "txtblock_Import", "如果您已经下载了部分或全部必要文件, 并且不希望本程序重新下载它们, 则可以在此处选择要导入程序的文件." },
                { "txtblock_Import", "Se você já baixou algum ou todos os arquivos necessários, e não quer que baixe novamente, você pode selecioná-los aqui, para que seja feita a importação." },
                { "txtblock_USBInstructions", "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (and do the steps above again).\r\n\r\nIf it still doesn't work, you may need to install QCMA manually and pick a driver other than libusbk." },
                { "txtblock_WifiInstructions", "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB." },

                { "btn_Import", "Eu já baixei um ou todos os arquivos e gostaria de usá-los ao invés de baixá-los novamente" },
                { "btn_Ok", "OK" },
                { "btn_Close", "Fechar" },
                { "btn_Start", "Iniciar" },
                { "btn_Done", "Feito" },
                { "btn_Browse", "Procurar" },
                { "btn_Next", "Next" },
                { "btn_USB", "USB" },
                { "btn_Wifi", "WiFi (Firmware 3.68 ONLY)" },

                { "cbx_Trim", "Tirar o conteúdo excessivo do demo bitter smile (reduz o tamanho do app h-encore de ~240MB para ~13MB)" },
                { "cbx_DeleteExisting", "Deletar arquivos existentes (faça isso se alguma coisa deu errada antes)" },
                { "cbx_OverrideHashes", "Ignorar Diferenças de Hash dos Arquivos" },

                { "browse_QCMA", "Procure sua pasta PS Vita do QCMA (está localizada na opção Settings do QCMA, em Applications / Backups)" },
                { "browse_Generic", "Procure por " },

                { "info_Finish",  "Para finalizar a instalação do h-encore:\r\n"
                        + "1. Connect your PS Vita to your PC using Content Manager like you did before (if it isn't still connected)\r\n"
                        + "     Se seu VITA disser que precisa atualizar, desligue o Wifi no seu Vita e reinicie o Vita\r\n"
                        + "4. No Gerenciador de Conteúdo, escolha PC -> Sistema PS Vita\r\n"
                        + "5. Selecione Aplicações\r\n"
                        + "6. Selecione PS Vita\r\n"
                        + "7. Selecione h-encore e clique em Copiar\r\n"
                        + "8. Abra o app h-encore na sua Live Area\r\n"
                        + "     Se travar na primeira vez, tente reiniciar seu Vita e inicie o app de novo\r\n\r\n"
                        + "Está feito!"},

                { "warn_HashCompat", "Compatibilidade não é garantida quando está usando versões de arquivos que essa aplicação não foi designada para tal. Continuar mesmo assim?" },
                { "warn_DeleteExistingBittersmile", "Você deve remover seu backup do bittersmile de sua pasta QCMA. Se deseja mantê-lo, deverá mover o backup agora. Remover?" },

                { "error_WebException", "Falha para baixar o arquivo. Por favor, verifique sua conexão." },
                { "error_Unknown", "Alguma coisa deu errado: {0}" },
                { "error_DirectoryNotFoundException", "Uma pasta que foi criada parece ter desaparecido (elas foram deletadas?) OU uma pasta falhou ao extrair OU você está usando um arquivo que não é suportado." },
                { "error_UnauthorizedAccessException", "A aplicação não tem acesso de escrita na pasta instalada. Tente reiniciar o aplicativo como Administrador." },
                { "error_FileNotFoundException",  "Um arquivo que foi criado parece ter desaparecido (eles foram deletados?) OU um arquivo falhou ao extrair OU você está usando um arquivo que não é suportado."},
                { "error_InvalidOperationException",  "Um download está corrompido. Tenha certeza que sua conexão é estável."},
                { "error_TargetInvocationException", "Falha ao criar calculadora MD5." },
                { "error_Template", "Erro {0} ocorrido.\r\n\r\n{1}\r\n\r\nPor favor reinicie o processo. Se você não conseguir resolver o problema, por favor crie um Problema no Rastreador de Erros (GitHub) com esse código." },
                { "error_Redownload",  "Erro 1001-0105\r\n\r\nFalha ao baixar arquivo {0}\r\n\r\nTenha certeza que sua Internet está conectada e/ou tente novamente. Se o erro persistir, por favor crie um Problema no Rastreador de Erros (GitHub)."},

                { "log_SearchingForQCMA", "Searching for QCMA..." },
                { "log_FoundQCMA", "Found QCMA." },
                { "log_QCMANotFound", "QCMA not found, will download." },
                { "log_KillingQCMA", "Killing any running QCMA processes..." },
                { "log_QCMARegistry", "Importing QCMA registry information..." },
                { "log_ScrubAID", "Scrubbing AID value" },
                { "log_Prompt", "Prompting user for information..." },
                { "log_Done", "        Feito!" },
                { "log_WipeFiles", "Deletando arquivos antigos..." },
                { "log_Import", "Importação do arquivo {0} válida." },
                { "log_DownloadValid", "Arquivo {0} já baixado e é válido, não baixar denovo." },
                { "log_DownloadInvalid", "Arquivo {0} já baixado mas hash não corresponde, irá baixar novamente." },
                { "log_NotDownloaded", "Arquivo {0} não baixado ou não importado, irá baixar." },
                { "log_WorkingDirs", "Gerando diretórios de trabalho..." },
                { "log_CorrectLocation", "Arquivo {0} no lugar correto, pulando." },
                { "log_Importing", "Importando {0}" },
                { "log_Downloading", "Baixando {0}" },
                { "log_Extracting", "Extraindo {0}" },
                { "log_ExtractingPKG", "Extraindo demo do bittersmile com pkg2zip..." },
                { "log_Trimming", "Tirando conteúdo excessivo do demo bittersmile..." },
                { "log_MoveToHencore", "Movendo {0} para diretório de trabalho do h-encore..." },
                { "log_MoveLicense", "Movendo arquivo de licença..." },
                { "log_GetCMA", "Pegando chave de encriptação CMA usando AID {0}" },
                { "log_GotCMA", "Pegou chave de encriptação CMA {0}" },
                { "log_Packaging", "Empacotando h-encore {0} usando psvimgtools..." },
                { "log_MoveToQCMA", "Movendo arquivos h-encore para o diretório QCMA APP...\r\n" },
                { "log_Finished", "auto h-encore Finalizado!!\r\n" },

                { "title_Main", "auto h-encore" },
                { "title_Import", "Importar Arquivos Existentes" },
                { "title_Warning", "Atenção" },
                { "title_Error", "Erro" }
            } },
            { "Français",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Choisis la langue :" },
                { "lbl_VersionText", "auto h-encore version " },
                { "lbl_Issues", "Issue Tracker" },
                { "lbl_ConnectionMethod", "How do you plan to connect your PS Vita to transfer h-encore?" },
                { "lbl_UnplugVita", "If your Vita is plugged in, unplug it, then click next." },
                { "lbl_InstallingUSB", "Installing USB driver, please wait..." },

                { "status_NoFile", "Aucun fichier n’a été sélectionné, pour être téléchargé." },

                { "status_Invalid", "Le chemin du fichier est invalide." },
                { "status_Valid", "Le fichier sélectionné et le Hash correspondent, importation." },
                { "status_BadHash", "Le fichier sélectionné et le Hash ne correspondent pas, pas d’importation." },
                { "status_Override", "Le fichier sélectionné et le Hash ne correspondant pas, mais le forcing est activé, importation." },
                { "status_Calculating", "Calcul du Hash du fichier..." },

                { "txtblock_BeforeRunning", "The application will automatically download QCMA if it is not installed. It will also automatically launch and manage it. That means:\r\n    If QCMA is not installed:\r\n        QCMA will be downloaded for local use by this program.\r\n        A USB driver will be installed if you choose to transfer via USB\r\n    If QCMA is installed:\r\n        Your existing QCMA installation will be used.\r\n        No new USB drivers will be installed, and your configuration will not be overwritten.\r\n\r\nBasically, you no longer need to interact with QCMA unless there are problems. If you have issues, please submit a report on the issue tracker."},                { "txtblock_Import", "如果您已经下载了部分或全部必要文件, 并且不希望本程序重新下载它们, 则可以在此处选择要导入程序的文件." },
                { "txtblock_Import", "Si vous avez déjà téléchargé une partie ou tous les fichiers nécessaires, et que vous ne voulez pas que l’application les télécharge à nouveau, vous pouvez la sélectionner ici pour que le programme les importe." },
                { "txtblock_USBInstructions", "Connect your PS Vita now.\r\n\r\nIf nothing happens:\r\n1. Launch Content Manager on your PS Vita\r\n2. Select Copy Content\r\n3. If prompted: Select PC and USB\r\n\r\nIf it still doesn't work, try restarting your computer and PS Vita and retry (and do the steps above again).\r\n\r\nIf it still doesn't work, you may need to install QCMA manually and pick a driver other than libusbk." },
                { "txtblock_WifiInstructions", "On your PS Vita:\r\n1. Launch Content Manager\r\n2. Select Copy Content\r\n3. Choose PC\r\n4. Choose Wifi\r\n5. Select Register\r\n6.Select the name of your PC\r\n7. Enter the code that appears on your PC\r\n\r\nIf it doesn't work, make sure your Vita and PC are on the same network, or rerun this application and try USB." },

                { "btn_Import", "J'ai déjà téléchargé une partie ou tous les fichiers et je préfère les utiliser que de les télécharger à nouveau." },
                { "btn_Ok", "OK" },
                { "btn_Close", "Fermer" },
                { "btn_Start", "Démarrer" },
                { "btn_Done", "Fini" },
                { "btn_Browse", "Parcourir" },
                { "btn_Next", "Next" },
                { "btn_USB", "USB" },
                { "btn_Wifi", "WiFi (Firmware 3.68 ONLY)" },

                { "cbx_Trim", "Réduit l’excès de contenu depuis la démo bitter smile (réduire la taille de l'application h-encore de ~240MB a ~13MB)" },
                { "cbx_DeleteExisting", "Supprimer les fichiers existants (Faites ceci si vous avez une erreur)" },
                { "cbx_OverrideHashes", "Ignorer les Hashes non conformes" },

                { "browse_QCMA", "Trouve le répertoire QCMA PS Vita (Trouvez ceci dans les paramètres de QCMA sous Applications / Backups)" },
                { "browse_Generic", "Parcourir pour " },

                { "info_Finish",  " Pour finir l'installation de h-encore:\r\n"
                        + "1. Connect your PS Vita to your PC using Content Manager like you did before (if it isn't still connected)\r\n"
                        + "     Si votre Vita demande une mise à jour, désactiver le wifi dans la Vita et redémarrer la\r\n"
                        + "4. Dans le gestionnaire de contenu, choisir PC -> PS Vita System\r\n"
                        + "5. Choisir Applications\r\n"
                        + "6. Choisir PS Vita\r\n"
                        + "7. Choisir h-encore et appuyez sur Copier\r\n"
                        + "8. Exécutez la bulle h-encore app depuis Le Live Area\r\n"
                        + "     Si ça plante à la 1ere utilisation, redémarrer votre Vita et lancez la bulle de nouveau\r\n\r\n"
                        + "Fini !"},

                { "warn_HashCompat", "La compatibilité avec cette version n'est pas sûre. On continue quand même ?" },
                { "warn_DeleteExistingBittersmile", "Vous devez supprimer le backup existant de bittersmile backup du répertoire QCMA. Si vous voulez le garder, déplacez-le maintenant. Supprimer ?" },

                { "error_WebException", "Erreur dans le téléchargement du fichier. Vérifiez votre connexion internet." },
                { "error_Unknown", "Quelque chose ne vas pas : {0}" },
                { "error_DirectoryNotFoundException", "Les répertoires qui ont étés créés ont disparu (Ils sont peut-être supprimés?) Ou bien, un répertoire n'a pas pu être extrait, ou alors, vous êtes en train d'utiliser une version de fichier non supporté." },
                { "error_UnauthorizedAccessException", "L'application n'a pas le droit d'accès au répertoire ou elle a été installée. Essayer de lancer l'application en mode Administrateur." },
                { "error_FileNotFoundException",  "Les fichiers qui ont étés créés ont disparus (Ils sont peut-être supprimés?) Ou bien un fichier n'a pas pu être extrait, ou alors, Vous êtes en train d'utiliser une version de fichier non supporté."},
                { "error_InvalidOperationException",  "Un téléchargement est corrompu. Vérifiez que votre connexion internet est stable."},
                { "error_TargetInvocationException", "Erreur dans la création du calculateur MD5." },
                { "error_Template", "Erreur {0} apparue. \r\n\r\n{1}\r\n\r\n Réessayez le processus. Si vous ne pouvez pas résoudre ce problème, S'il vous plait créez un rapport d'erreur dans l'Issue Tracker avec ce code d'erreur." },
                { "error_Redownload",  "Erreur 1001-0105\r\n\r\n Impossible de télécharger le fichier {0}\r\n\r\n Assurer vous que vous êtes connecté à internet et réessayez. Si ça ne marche toujours pas, s'il vous plait créez un rapport d'erreur sur le GitHub de l'application."},

                { "log_SearchingForQCMA", "Searching for QCMA..." },
                { "log_FoundQCMA", "Found QCMA." },
                { "log_QCMANotFound", "QCMA not found, will download." },
                { "log_KillingQCMA", "Killing any running QCMA processes..." },
                { "log_QCMARegistry", "Importing QCMA registry information..." },
                { "log_ScrubAID", "Scrubbing AID value" },
                { "log_Prompt", "Prompting user for information..." },
                { "log_Done", "        Fini !" },
                { "log_WipeFiles", "Suppression des anciens fichiers..." },
                { "log_Import", "Importation de fichier pour le fichier {0} valide." },
                { "log_DownloadValid", "Fichier {0} déjà téléchargé et valide, Pas de re-téléchargement." },
                { "log_DownloadInvalid", "Fichier {0} déjà téléchargé mais le Hash ne correspond pas, re-téléchargement." },
                { "log_NotDownloaded", "Fichier {0} pas encore téléchargé ou bien importé, téléchargement." },
                { "log_WorkingDirs", "Génération des répertoires temporaires..." },
                { "log_CorrectLocation", "Fichier {0} dans le bon répertoire, saut du fichier." },
                { "log_Importing", "Importation {0}" },
                { "log_Downloading", "Téléchargement {0}" },
                { "log_Extracting", "Extraction {0}" },
                { "log_ExtractingPKG", "Extraction de la démo bittersmile avec pkg2zip..." },
                { "log_Trimming", "Suppression des fichiers non nécessaires de la demo bittersmile..." },
                { "log_MoveToHencore", "Déplacement de {0} a le répertoire temporaire de h-encore..." },
                { "log_MoveLicense", "Déplacement du fichier de licence..." },
                { "log_GetCMA", "Obtention de la clé de cryptage CMA utilisant L’AID {0}" },
                { "log_GotCMA", "Clé de cryptage CMA obtenu {0}" },
                { "log_Packaging", "Mise en paquet de h-encore {0} en utilisant psvimgtools..." },
                { "log_MoveToQCMA", "Déplacement des fichiers h-encore à la répertoire QCMA APP ...\r\n" },
                { "log_Finished", "Auto h-encore a terminé son programme!\r\n" },

                { "title_Main", "auto h-encore" },
                { "title_Import", "Importer les fichiers existants" },
                { "title_Warning", "Attention" },
                { "title_Error", "Erreur" }
            } }
        };

        public static Dictionary<string, string> MountedLanguage = Languages["English"];
    }
}

