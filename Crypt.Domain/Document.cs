namespace Crypt.Domain
{
    public class Document
    {
        public long Id { get; set; }
        public string UserDocumentHash { get; set; } = string.Empty;
        public string UserDocument { get; set; } = string.Empty;
    }
}
