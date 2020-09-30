using System;

public class MessageItem
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime PostedDate { get; set; }
    public MessageUser PostedBy { get; set; }

    public MessageItem()
    {
        PostedDate = DateTime.Now;
    }
}

public class MessageUser
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string EmailAddress { get; set; }
}