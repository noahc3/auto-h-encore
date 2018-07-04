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
                { "lbl_AID", "Account ID (AID)" },
                { "lbl_QCMADir", "QCMA PS Vita directory" },
                { "lbl_HowToAID", "How do I get this information?" },
                { "lbl_VersionText", "auto h-encore version " },
                { "lbl_Issues", "Issue Tracker" },

                { "status_NoFile", "No file selected, will download." },
                { "status_Invalid", "File path is invalid." },
                { "status_Valid", "File selected and hash matches, will import." },
                { "status_BadHash", "File selected but hash does not match, will download." },
                { "status_Override", "File selected but hash does not match. Hash override enabled, will import." },
                { "status_Calculating", "Calculating file hash..." },

                { "txtblock_BeforeRunning", "Before running: \r\n1. Install QCMA\r\n2. Open QCMA\r\n3. Connect your Vita to your PC using USB and launch Content Manager\r\n4. Select Copy Content to connect your Vita to your PC\r\n   If your Vita says you need to update, turn off Wifi and restart the console\r\n\r\nEverything is now ready. Enter the above information correctly to enable the start button\r\n\r\nIf the start button does not enable, make sure your AID is 16 characters long and that you've selected the correct PS Vita folder (it should have an APP directory in it)."},
                { "txtblock_Import", "If you've already downloaded some or all of the necessary files, and don't want the application to redownload them, you can select the files here for the program to import." },
                { "txtblock_HowToInfo",  "The program should have tried to get this info automatically. If it didn't or you want to verify that it is correct: \r\n\r\n1. Install QCMA\r\n2. Open QCMA\r\n3. Connect your Vita to your PC using USB and launch Content Manager\r\n4. Select Copy Content to connect your Vita to your PC\r\n   If your Vita says you need to update, turn off Wifi and restart the console\r\n5. Right click QCMA in task tray, select settings\r\n6.Copy the directory named Applications / Backups into this application as the PS Vita directory \r\n7. Navigate to the directory you just copied and go into the APP folder\r\n8. Your AID is the name of the folder inside this directory (it should be 16 characters)"},

                { "btn_Import", "I've already downloaded some or all of the files and would like to use them rather than redownload them" },
                { "btn_Ok", "OK" },
                { "btn_Close", "Close" },
                { "btn_Start", "Start" },
                { "btn_Done", "Done" },
                { "btn_Browse", "Browse" },

                { "cbx_Trim", "Trim excess content from bitter smile demo (reduces h-encore app size from ~240MB to ~13MB)" },
                { "cbx_DeleteExisting", "Delete existing files (do this if something went wrong before)" },
                { "cbx_OverrideHashes", "Ignore Mismatch File Hashes" },

                { "browse_QCMA", "Locate your QCMA PS Vita directory (find it in QCMA settings under Applications / Backups)" },
                { "browse_Generic", "Browse for " },

                { "info_Finish",  "To finish your h-encore installation:\r\n"
                        + "1. Right click the QCMA icon in task tray and select refresh database\r\n"
                        + "2. Connect your PS Vita to your PC using USB\r\n"
                        + "3. Open Content Manager on your PS Vita and select Copy Content\r\n"
                        + "     If it says you need to update your firmware, turn off Wifi on your Vita and restart the Vita\r\n"
                        + "4. In Content Manager, choose PC -> PS Vita System\r\n"
                        + "5. Select Applications\r\n"
                        + "6. Select PS Vita\r\n"
                        + "7. Select h-encore and hit Copy\r\n"
                        + "8. Run the h-encore app from the Live Area\r\n"
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
                { "lbl_AID", "账号 ID (AID)" },
                { "lbl_QCMADir", "QCMA PS Vita 备份目录" },
                { "lbl_HowToAID", "我如何获取这些信息?" },
                { "lbl_VersionText", "自动 h-encore 版本 " },
                { "lbl_Issues", "问题追踪器" },

                { "status_NoFile", "未选中任何文件, 将开始下载." },
                { "status_Invalid", "文件目录无效." },
                { "status_Valid", "已选择文件且校验通过, 即将导入." },
                { "status_BadHash", "已选择文件但校验未通过, 将开始下载." },
                { "status_Override", "已选择文件且校验未通过. 已忽略不匹配校验信息, 即将导入." },
                { "status_Calculating", "校验中..." },

                { "txtblock_BeforeRunning", "运行之前: \r\n1. 安装 QCMA\r\n2. 打开 QCMA\r\n3. USB连接你的PSV和电脑并启动 内容管理 应用\r\n4. 选择 复制内容 使Vita和PC连接\r\n   如果你的 Vita 提示您需要更新系统, 关闭Vita的 Wifi 并重启Vita\r\n\r\n一切就绪,正确输入顶部的信息以激活开始按钮\r\n\r\n如果开始按钮未被激活,请确保你的 AID 为16字符并且你选择了正确的 PS Vita 备份目录 (里面应当有一个 APP 文件夹).."},
                { "txtblock_Import", "如果您已经下载了部分或全部必要文件, 并且不希望本程序重新下载它们, 则可以在此处选择要导入程序的文件." },
                { "txtblock_HowToInfo",  "本程序已尝试自动获取上述信息. 如果获取失败, 或者您想验证它是否正确: \r\n\r\n1. 安装 QCMA\r\n2. 启动 QCMA\r\n3. USB连接你的PSV和电脑 并启动 内容管理 应用\r\n4. 选择 复制内容 使Vita和PC连接\r\n   如果你的 Vita 提示更新系统, 关闭Vita的 Wifi 并重启Vita\r\n5. 右键点击 QCMA 任务栏图标, 选择 设置 命令\r\n6.复制 应用 / 备份 目录地址并输入到本程序 数据备份目录 位置 \r\n7. PC端打开上一步提到的应用备份目录并进入 APP 文件夹\r\n8. 你的 AID 是APP文件夹下的文件夹名称 (应当是16位字符)"},

                { "btn_Import", "我已经下载了一部分或者全部必要的文件, 我想使用它们, 不要重新下载" },
                { "btn_Ok", "确定" },
                { "btn_Close", "关闭" },
                { "btn_Start", "启动" },
                { "btn_Done", "完成" },
                { "btn_Browse", "浏览" },

                { "cbx_Trim", "删减 bitter smile demo 的多余内容 (将 h-encore app 大小 从 240MB 减小到 13MB)" },
                { "cbx_DeleteExisting", "删除已存在的文件 (如果之前的操作出错，请勾选它)" },
                { "cbx_OverrideHashes", "忽略不匹配的文件校验信息" },

                { "browse_QCMA", "请选择你的 PS Vita/APP 目录 (可以在 QCMA 设置界面找到)" },
                { "browse_Generic", "Browse for " },

                { "info_Finish",  "完成 h-encore 安装:\r\n"
                        + "1. 右键点击 QCMA 任务栏图标并选择刷新数据库\r\n"
                        + "2. 用USB连接你的电脑和 PSV\r\n"
                        + "3. 打开Vita端 内容管理 程序并点击 复制内容\r\n"
                        + "     如果Vita提示你需要更新系统, 关闭无线网络后重启 Vita\r\n"
                        + "4. 在 内容管理 程序界面, 选择 电脑 -> PS Vita\r\n"
                        + "5. 选择 应用程序\r\n"
                        + "6. 选择 PS Vita\r\n"
                        + "7. 选择 h-encore 并点击 复制\r\n"
                        + "8. 启动主界面的 h-encore 程序\r\n"
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
            } };
                    public static Dictionary<string, Dictionary<string, string>> Languages = new Dictionary<string, Dictionary<string, string>> {
            { "Русский",  new Dictionary<string, string> {
                { "lbl_ChooseLanguage", "Выберите язык:" },
                { "lbl_AID", "ID Аккаунта (AID)" },
                { "lbl_QCMADir", "Директория QCMA PS Vita" },
                { "lbl_HowToAID", "Где мне узнать эту информацию?" },
                { "lbl_VersionText", "Версия auto h-encore " },
                { "lbl_Issues", "Issue-трекер" },

                { "status_NoFile", "Файл не выбран, файл будет скачан." },
                { "status_Invalid", "Неверный путь к файлу." },
                { "status_Valid", "Файл выбран,и проверка хэша прошла успешно." },
                { "status_BadHash", "Файл выбран,но хэш не прошел проверку, файл будет переустановлен." },
                { "status_Override", "Файл выбран,но хэш не прошел проверку. Перепроверка хэша запущена, он будет импортирован." },
                { "status_Calculating", "Расчет хэша файла..." },

                { "txtblock_BeforeRunning", "Прежде чем начать: \r\n1. Установите QCMA\r\n2. Откройте QCMA\r\n3. Подключите PS Vita к компьютеру через USB и откройте Управление данными\r\n4. Нажмите Скопировать данные для подключения PS Vita к компьютеру\r\n   Если требует обновить прошивку,выключите wi-fi на Vita и перезагрузите ее\r\n\r\nВсе готово. Введите верную информацию,чтобы кнопка активировалась\r\n\r\nЕсли кнопка Начать недоступна, проверьте ваш AID,он должен состоять из 16 символов,и вы выбрали правильную папку PS Vita(она должна содержать папку APP)."},
                { "txtblock_Import", "Если вы заранее установили все нужные файлы, и не хотите чтоб программа снова их установила, здесь вы можете выбрать уже имеющиеся файлы." },
                { "txtblock_HowToInfo",  "Программа найдет эту информацию самостоятельно. Если она не нашла,то: \r\n\r\n1. Установите QCMA\r\n2. Откройте QCMA\r\n3. Подключите PS Vita к компьютеру через USB и откройте Управление данными\r\n4. Нажмите Скопировать данные для подключения PS Vita к компьютеру\r\n   Если требует обновить прошивку,выключите wi-fi на Vita и перезагрузите ее\r\n5. Нажмите правой кнопкой мыши на иконку QCMA в трее и нажмите settings\r\n6.Скопируйте директорию с названием Applications / Backups в эту программу как директорию PS Vita \r\n7. Зайдите в папку APP в той директории которую вы только что скопировали\r\n8. Ваш AID - это имя папки внутри этой директории(убедитесь,что в ней 16 символов)"},

                { "btn_Import", "Я уже загрузил некоторые или все файлы и хотел бы использовать их, а не загружать их заново." },
                { "btn_Ok", "OK" },
                { "btn_Close", "Закрыть" },
                { "btn_Start", "Начать" },
                { "btn_Done", "Готово" },
                { "btn_Browse", "Обзор" },

                { "cbx_Trim", "Обрезать лишний контент из bittersmile demo (размер h-encore уменьшается с ~240MB до ~13MB)" },
                { "cbx_DeleteExisting", "Удаление лишних файлов (сделайте это,если ранее что-то пошло не так)" },
                { "cbx_OverrideHashes", "Игнорировать несоответствие хэша" },

                { "browse_QCMA", "Откройте директорию QCMA PS Vita (найдите ее в настройках QCMA (Applications / Backups)" },
                { "browse_Generic", "Обзор " },

                { "info_Finish",  "Чтобы закончить установку h-encore:\r\n"
                        + "1. Нажмите правой кнопкой мыши на иконку QCMA в трее и нажмите Refresh database\r\n"
                        + "2. Подключите вашу PS Vita к компьютеру через USB\r\n"
                        + "3. Откройте Управление данными на вашей PS Vita и нажмите Скопировать данные\r\n"
                        + "     Если требует обновить прошивку,выключите wi-fi на Vita и перезагрузите ее\r\n"
                        + "4. В Управлении данными, нажмите Компьютер -> Система PS Vita\r\n"
                        + "5. Нажмите Приложения\r\n"
                        + "6. Нажмите PS Vita\r\n"
                        + "7. Выберите h-encore и нажмите Скопировать\r\n"
                        + "8. Запустите h-encore в LiveArea\r\n"
                        + "     Если h-encore вылетает,перезагрузите PS Vita и попробуйте снова\r\n\r\n"
                        + "Готово!"},

                { "warn_HashCompat", "Совместимость не гарантируется при использовании версий файлов, для которых это приложение не предназначено. Все равно продолжить?" },
                { "warn_DeleteExistingBittersmile", "Вы должны удалить существуший бэкап bittersmile из вашей директории QCMA directory. Если вы хотите ее оставить,просто переместите. Удалить?" },

                { "error_WebException", "Неудалось загрузить файл,проверьте ваше соединение." },
                { "error_Unknown", "Что-то пошло не так: {0}" },
                { "error_DirectoryNotFoundException", "Созданная директория, кажется, исчезла (может,она была удалена?),в директорию не удалось распаковать ранее,или вы хотите импортировать неподдерживаемый файл." },
                { "error_UnauthorizedAccessException", "Программа не получила доступа к директории. Попробуйте перезапустить программу от имени администратора." },
                { "error_FileNotFoundException",  "Созданный файл, кажется, исчезла (может,она была удалена?),в директорию не удалось распаковать ранее,или вы хотите импортировать неподдерживаемый файл."},
                { "error_InvalidOperationException",  "Файл был поврежден. Убедитесь в стабильности вашего интернет соединения."},
                { "error_TargetInvocationException", "Неудалось создать MD5 калькулятор." },
                { "error_Template", "Произошла ошибка {0}.\r\n\r\n{1}\r\n\r\nПовторите процесс. Если вы не можете решить проблемму,пожалуйста, создайте issue в issue-трекере с этим кодом ошибки." },
                { "error_Redownload",  "Ошибка 1001-0105\r\n\r\nНеудалось установить файл {0}\r\n\r\nПроверьте подключение к интернету,и попробуйте снова. Если все в порядке,а ошибка не пропадает,создайте issue на GitHub."},

                { "log_Done", "        Готово!" },
                { "log_WipeFiles", "Удаление старых файлов..." },
                { "log_Import", "Импорт файла для {0} прошло успешно." },
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
        };

        public static Dictionary<string, string> MountedLanguage = Languages["English"];
    }
}
