using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_h_encore {
    public static class Reference {
        public static readonly string version = "0.2.0";

        public static readonly string path_hencore = Environment.CurrentDirectory + "\\data\\h-encore\\";
        public static readonly string path_psvimgtools = Environment.CurrentDirectory + "\\data\\psvimgtools\\";
        public static readonly string path_downloads = Environment.CurrentDirectory + "\\data\\downloads\\";
        public static readonly string path_data = Environment.CurrentDirectory + "\\data\\";

        public static readonly string fpath_raw_hencore = path_downloads + "hencore.zip";
        public static readonly string fpath_raw_pkg2zip = path_downloads + "pkg2zip.zip";
        public static readonly string fpath_raw_psvimgtools = path_downloads + "psvimgtools.zip";
        public static readonly string fpath_raw_bittersmile = path_downloads + "bittersmile.pkg";

        public static readonly string fpath_pkg2zip = path_downloads + "pkg2zip.exe";
        public static readonly string fpath_psvimagetools = path_psvimgtools + "psvimg-create.exe";

        public static readonly string url_bittersmile = "http://ares.dl.playstation.net/cdn/JP0741/PCSG90096_00/xGMrXOkORxWRyqzLMihZPqsXAbAXLzvAdJFqtPJLAZTgOcqJobxQAhLNbgiFydVlcmVOrpZKklOYxizQCRpiLfjeROuWivGXfwgkq.pkg";
        public static readonly string url_psvimgtools = "https://github.com/yifanlu/psvimgtools/releases/download/v0.1/psvimgtools-0.1-win32.zip";
        public static readonly string url_pkg2zip = "https://github.com/mmozeiko/pkg2zip/releases/download/v1.8/pkg2zip_32bit.zip";
        public static readonly string url_hencore = "https://github.com/TheOfficialFloW/h-encore/releases/download/v1.0/h-encore.zip";
        public static readonly string url_cma = "http://cma.henkaku.xyz/?aid=";

        public static readonly string hash_hencore = "d0b1bad1b52d8e2464ebf3aab5fc5401";
        public static readonly string hash_pkg2zip = "10cf8255126521ee59fd884cf09c1e30";
        public static readonly string hash_psvimgtools = "44696426da9440b45fcef9ec2845a042";
        public static readonly string hash_bittersmile = "ce3badfc04ae24e7c209f1a2fd565943";

        public static readonly string[] hashes = new string[] {
            hash_hencore, hash_pkg2zip, hash_psvimgtools, hash_bittersmile
        };

        public static readonly string[] raws = new string[] {
            fpath_raw_hencore, fpath_raw_pkg2zip, fpath_raw_psvimgtools, fpath_raw_bittersmile
        };

        public static readonly string[] downloads = new string[] {
            url_hencore, url_pkg2zip, url_psvimgtools, url_bittersmile
        };

        public static readonly string[] paths = new string[] {
            path_hencore, path_downloads, path_psvimgtools
        };
    }
}
