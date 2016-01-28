using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public interface IHtmlElement
    {
        string GetTag(MyHashTable<string, string> errors = null);
    }
}
