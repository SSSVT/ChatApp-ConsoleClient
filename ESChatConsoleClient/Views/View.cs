using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public abstract class View
    {
        protected ClientEngine ClientEngine { get; set; }

        protected List<ViewItem> viewItems = new List<ViewItem>();
        protected int SelectedIndex { get; set; }

        protected ViewItem SelectedViewItem
        {
            get
            {
                return this.viewItems[SelectedIndex];
            }
        }

        public View(ClientEngine clientEngine)
        {
            this.ClientEngine = clientEngine;
        }

        public void Draw()
        {
            Console.Clear();

            foreach (ViewItem item in this.viewItems)
            {
                item.Draw();
            }
        }

        protected void AddViewItems(params ViewItem[] items)
        {
            foreach (ViewItem item in items)
            {
                this.viewItems.Add(item);
            }
        }

        protected void SelectViewItem(int index)
        {
            this.SelectedViewItem.Selected = false;

            this.SelectedIndex = index;
            this.SelectedViewItem.Selected = true;
        }
        
        public void OnInput(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                    this.MoveDown();
                    break;

                case ConsoleKey.UpArrow:
                    this.MoveUp();
                    break;

                case ConsoleKey.Enter:
                    this.ExecuteSelected();
                    break;

                case ConsoleKey.Backspace:
                    this.DeleteInput();
                    break;

                case ConsoleKey.Escape:
                    this.Back();
                    break;

                case ConsoleKey.Tab:
                    this.CycleViewItems();
                    break;

                default:
                    this.WriteInput(consoleKeyInfo.KeyChar);
                    break;
            }
        }

        private void CycleViewItems()
        {
            if (this.SelectedViewItem != this.viewItems.Last())
            {
                this.SelectViewItem(this.SelectedIndex + 1);
            }
            else
            {
                this.SelectViewItem(0);
            }
        }

        protected void MoveDown()
        {
            if (this.SelectedIndex != (this.viewItems.Count-1))
            {
                this.SelectViewItem(SelectedIndex + 1);
            }
        }

        protected void WriteInput(char input)
        {
            if (this.SelectedViewItem is InputViewItem)
            {
                InputViewItem inputViewItem = (InputViewItem) this.SelectedViewItem;
                inputViewItem.Value += input;
            }
        }

        protected void DeleteInput()
        {
            if (this.SelectedViewItem is InputViewItem)
            {
                InputViewItem inputViewItem = (InputViewItem)this.SelectedViewItem;
                if (inputViewItem.Value.Length > 0)
                {
                    inputViewItem.Value = inputViewItem.Value.Remove(inputViewItem.Value.Length - 1);
                }
                
            }
        }

        protected void MoveUp()
        {
            if (this.SelectedIndex > 0)
            {
                this.SelectViewItem(SelectedIndex - 1);
            }
        }

        protected void ExecuteSelected()
        {
            if (this.SelectedViewItem is ActionViewItem)
            {
                ActionViewItem actionViewItem = (ActionViewItem)this.SelectedViewItem;
                actionViewItem.Execute();
            }
        }

        protected void Back()
        {
            this.ClientEngine.PopView();
        }
    }
}
