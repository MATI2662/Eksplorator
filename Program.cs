DirectoryInfo selected_folder = new DirectoryInfo(@"C:/");
int selected_folder_index = 0;

DirectoryInfo[] selected_folder_folders = selected_folder.GetDirectories();
FileInfo[] selected_folder_files = selected_folder.GetFiles();

void Write()
{
    Console.Clear();
    Console.ResetColor();

    Console.WriteLine(selected_folder.FullName);

    for (int i = 0; i < selected_folder_folders.Length; i++)
    {
        Console.Write(i == selected_folder_files.Length - 1 && selected_folder_files.Length == 0 ? "└" : "├");
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (i == selected_folder_index) Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\t" + selected_folder_folders[i].Name);
        Console.ResetColor();
    }

    for (int j = 0; j < selected_folder_files.Length; j++)
    {
        Console.Write(j == selected_folder_files.Length - 1 ? "└" : "├");
        Console.WriteLine("\t" + selected_folder_files[j].Name);
    }
}

Write();

while (true)
{
    if (Console.ReadKey(true).Key == ConsoleKey.DownArrow)
    {
        selected_folder_index = selected_folder_index == selected_folder_folders.Length - 1 ? selected_folder_folders.Length - 1 : selected_folder_index + 1;
        Write();
    }

    if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
    {
        selected_folder_index = selected_folder_index == 0 ? 0 : selected_folder_index - 1;
        Write();
    }

    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
    {
        selected_folder = selected_folder_folders[selected_folder_index];
        selected_folder_index = 0;
        try
        {
            selected_folder_folders = selected_folder.GetDirectories();
        } 
        catch
        {

        }

        try
        {
            selected_folder_files = selected_folder.GetFiles();
        }
        catch
        {

        }

        Write();
    }

    if (Console.ReadKey(true).Key == ConsoleKey.Backspace)
    {
        if(selected_folder.Parent != null)
        {
            selected_folder = selected_folder.Parent;
            selected_folder_index = 0;

            selected_folder_folders = selected_folder.GetDirectories();
            selected_folder_files = selected_folder.GetFiles();

            Write();
        }
    }

}
