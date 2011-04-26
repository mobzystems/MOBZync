using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using System.Drawing;

namespace MOBZystems
{
  /// <summary>
  /// Contains an image list that mimics the system image list.
  /// It is used through AddIconForFile. This adds the icon for a file
  /// to the image list. Based on the icon index of the file,
  /// the icon is added to the list or skipped.
  /// </summary>
  public class SystemImageList
  {
    #region Members
    // The list of icon indices present in the image list
    private List<int> iconIndexList = new List<int>();
    // The actual image list
    private ImageList imageList = new ImageList();
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor
    /// </summary>
    public SystemImageList(Size size /*, Color backgroundColor */)
    {
      // this.imageList.TransparentColor = backgroundColor;
      this.imageList.TransparentColor = Color.Transparent;
      // Set the size of this image list
      this.imageList.ImageSize = size;
      // The color depth of the image list
      this.imageList.ColorDepth = ColorDepth.Depth32Bit;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Property ImageList (ImageList). The image list that contains the icons added
    /// </summary>
    public ImageList ImageList
    {
      get
      {
        return this.imageList;
      }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Internal method that adds an image to the image list based on an icon handle.
    /// </summary>
    /// <param name="iconHandle">The HICON to add</param>
    private void AddIconHandle(IntPtr iconHandle)
    {
      // Create an icon using the icon handle
      using (Icon icon = Icon.FromHandle(iconHandle))
      {
        this.imageList.Images.Add(icon);

        //// Add a bitmap version of it to the internal image list

        //// Create a bitmap of the right size, 24-bit with transparency
        //Bitmap bitmap = new Bitmap(icon.Width, icon.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //// Draw the icon onto the bitmap, using the transparent color as the background
        //using (Graphics g = Graphics.FromImage(bitmap))
        //{
        //  g.Clear(this.imageList.TransparentColor);
        //  g.DrawIcon(icon, 0, 0);
        //}
        //// Add the bitmap to the image list
        //this.imageList.Images.Add(bitmap);
      }
    }

    /// <summary>
    /// Add the file icon to the system image list
    /// </summary>
    /// <param name="filename">The file to get the icon for</param>
    /// <param name="getLargeIcon">True for large icons, False for small</param>
    /// <returns>The index in the internal image list or -1 on error</returns>
    public int AddIconForFile(string filename, bool getLargeIcon)
    {
      // Determine icon index of the file for the system image list 
      int iconIndex = SHFileInfo.GetFileIconIndex(filename, getLargeIcon);
      // No icon found? Then don't add, return -1
      if (iconIndex == -1)
        return -1;

      // Find the icon index in the index list
      int index = this.iconIndexList.IndexOf(iconIndex);
      // Found it? Then return it and do nothing -- the icon is already present
      if (index >= 0)
        return index;

      // If not found, we need to add an icon handle for the file to the image list

      // Retrieve the icon for the file
      IntPtr iconHandle = SHFileInfo.GetFileIconHandle(filename, getLargeIcon);

      // Add the icon to the internal image list
      this.AddIconHandle(iconHandle);

      // ALso add the icon index to the index list
      this.iconIndexList.Add(iconIndex);

      // Return the index of the image
      // return this.iconIndexList.Count - 1;
      return this.imageList.Images.Count - 1;
    }
    #endregion
  }
}
