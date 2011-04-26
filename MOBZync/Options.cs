using System;
using System.Collections.Generic;
using System.Text;

namespace MOBZync
{
  public class Options
  {
    public enum Action
    {
      Skip,
      Copy,
      Delete
    }

    public enum Direction
    {
      LeftToRight,
      RightToLeft,
      Synchronize
    }

    public Direction direction;
    public Action addedFilesAction = Action.Skip;
    public Action changedFilesAction = Action.Skip;
    public Action unchangedFilesAction = Action.Skip;
  }
}
