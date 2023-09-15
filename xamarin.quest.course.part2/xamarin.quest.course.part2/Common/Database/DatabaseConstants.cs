using System;
using System.IO;

namespace xamarin.quest.course.part2.Common.Database
{
    public static class DatabaseConstants
    {
        public const string DatabaseFileName = "MoviesSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // Open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Create the Database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // Enable multi-threaded Database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }
}
