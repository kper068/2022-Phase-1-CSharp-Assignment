namespace LibraryService;

public sealed class LibraryService : ILibraryService
{

  private List<IItem> _items = new List<IItem>();

  public LibraryService() { }

  public IItem GetItem(string id)
  {
    foreach (IItem item in _items)
    {
      if (item.Id == id)
      {
        return item;
      }
    }
    throw new InvalidOperationException();
  }

  public void AddItem(IItem item)
  {
    foreach (IItem currentItem in _items)
    {
      if (currentItem == item)
      {
        throw new InvalidOperationException();
      }
    }
    _items.Add(item);
  }

  public void RemoveItem(string id)
  {
    IItem currentItem = GetItem(id);
    _items.Remove(currentItem);
  }

  public void BorrowItem(string id, Person borrower)
  {
    IItem currentItem = GetItem(id);
    currentItem.BorrowItem(borrower);
  }

  public void ReturnItem(string id, Person returnee)
  {
    IItem currentItem = GetItem(id);
    currentItem.ReturnItem(returnee);
  }
}
