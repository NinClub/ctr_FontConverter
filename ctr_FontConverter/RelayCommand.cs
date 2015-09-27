// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.RelayCommand
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Diagnostics;
using System.Windows.Input;

namespace NintendoWare.Font
{
  public class RelayCommand : ICommand
  {
    private readonly Action<object> a;
    private readonly Predicate<object> b;

    public string Text { get; set; }

    public event EventHandler CanExecuteChanged
    {
      add
      {
        CommandManager.RequerySuggested += value;
      }
      remove
      {
        CommandManager.RequerySuggested -= value;
      }
    }

    public RelayCommand(Action<object> execute)
      : this(execute, (Predicate<object>) null)
    {
    }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
      if (execute == null)
        throw new ArgumentNullException("execute");
      this.a = execute;
      this.b = canExecute;
    }

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
      if (this.b != null)
        return this.b(parameter);
      return true;
    }

    public void Execute(object parameter)
    {
      this.a(parameter);
    }
  }
}
