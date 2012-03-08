using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundKeyboard2012
{
    public class SoundPackList : IList<SoundPack>
    {
        private List<SoundPack> items = null;
        private SoundPack selected = null;

        public event EventHandler SelectIndexChanged;
        public event EventHandler Loaded;

        public SoundPackList(string path)
        {
            Location = path;
        }

        public void Load()
        {
            items = new System.IO.DirectoryInfo(Location)
                .GetDirectories()
                .Select(_ => new SoundPack(_.FullName))
                .ToList();

            if (Loaded != null) Loaded(this, EventArgs.Empty);
        }

        public string Location { get; private set; }

        public int SelectedIndex
        {
            get
            {
                return items.IndexOf(selected);
            }
            set
            {
                if (SelectedIndex != value)
                {
                    selected = items[value];

                    if (SelectIndexChanged != null)
                        SelectIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public SoundPack SelectedItem
        {
            get
            {
                return selected;
            }
            set
            {
                if (selected != value)
                {
                    selected = value;

                    if (SelectIndexChanged != null)
                        SelectIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public string SelectedName
        {
            get
            {
                return selected.Name;
            }
            set
            {
                if (selected.Name != value)
                {
                    selected = items.Find(_ => value == _.Name);

                    if (SelectIndexChanged != null)
                        SelectIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public int IndexOf(SoundPack item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, SoundPack item)
        {
            items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public SoundPack this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public void Add(SoundPack item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(SoundPack item)
        {
            return items.Contains(item);
        }

        public void CopyTo(SoundPack[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return items.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(SoundPack item)
        {
            return items.Remove(item);
        }

        public IEnumerator<SoundPack> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }

    public class SoundPack
    {
        private SoundPack()
        {

        }

        public SoundPack(string location)
        {
            Location = location;
        }

        public string Location { get; set; }

        public string Name
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(Location);
            }
        }

        public bool ActiveIn(SoundPackList list)
        {
            return list.IndexOf(this) == list.SelectedIndex;
        }
    }
}
