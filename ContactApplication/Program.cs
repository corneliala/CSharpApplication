
using ContactApplication.Services;

var menuManager = new MenuManager();
menuManager.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

while(true)
{
    Console.Clear();
    menuManager.OptionMenu();
}