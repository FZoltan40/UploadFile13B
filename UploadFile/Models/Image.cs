using System;
using System.Collections.Generic;

namespace UploadFile.Models;

public partial class Image
{
    public int Id { get; set; }

    public byte[] ImageData { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string ContentType { get; set; } = null!;
}
