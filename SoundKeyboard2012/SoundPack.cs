using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;

namespace SoundKeyboard2012
{
    public class SoundPackList : IList<SoundPack>
    {
        private List<SoundPack> mItems = null;
        private int mSelectedIndex = -1;

        public event EventHandler SelectIndexChanged;
        public event EventHandler Loaded;

        public SoundPackList(string path)
        {
            Location = path;
        }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                var doc = new XmlDocument();
                doc.Load(path);

                mItems = doc.SelectNodes("/SoundPackList/Items/SoundPack/Location")
                    .Cast<XmlNode>()
                    .Select(_ => new SoundPack(_.InnerText))
                    .ToList();

                mSelectedIndex = int.Parse(
                    doc.SelectSingleNode("/SoundPackList/SelectIndex").InnerText
                );
            }
            else
            {
                mItems = new System.IO.DirectoryInfo(Location)
                    .GetDirectories()
                    .Select(_ => new SoundPack(_.FullName))
                    .ToList();

                mSelectedIndex = 0;
            }

            // event: Load -> SelectedIndexChanged

            if (Loaded != null)
                Loaded(this, EventArgs.Empty);

            if (SelectIndexChanged != null)
                SelectIndexChanged(this, EventArgs.Empty);
        }

        public void Save(string path)
        {
            var doc = new XmlDocument();

            var sound_pack_list = doc.CreateElement("SoundPackList");
            doc.AppendChild(sound_pack_list);

            var select_index = doc.CreateElement("SelectIndex");
            select_index.InnerText = SelectedIndex.ToString();
            sound_pack_list.AppendChild(select_index);

            var items = doc.CreateElement("Items");
            sound_pack_list.AppendChild(items);

            foreach (var item in mItems)
            {
                var location = doc.CreateElement("Location");
                location.InnerText = item.Location;

                var sound_pack = doc.CreateElement("SoundPack");
                sound_pack.AppendChild(location);

                items.AppendChild(sound_pack);
            }

            doc.Save(path);
        }

        public string Location { get; private set; }

        public int SelectedIndex
        {
            get
            {
                return mSelectedIndex;
            }
            set
            {
                if (mSelectedIndex != value)
                {
                    mSelectedIndex = value;

                    if (SelectIndexChanged != null)
                        SelectIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public SoundPack SelectedItem
        {
            get
            {
                return mItems[mSelectedIndex];
            }
            set
            {
                int index = mItems.IndexOf(value);

                if (mSelectedIndex != index)
                {
                    mSelectedIndex = index;

                    if (SelectIndexChanged != null)
                        SelectIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public string SelectedName
        {
            get
            {
                return SelectedItem.Name;
            }
            set
            {
                if (SelectedItem.Name != value)
                {
                    var pack = mItems.Where(_ => _.Name == value).Single();

                    mSelectedIndex = mItems.IndexOf(pack);

                    if (SelectIndexChanged != null)
                        SelectIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public int IndexOf(SoundPack item)
        {
            return mItems.IndexOf(item);
        }

        public void Insert(int index, SoundPack item)
        {
            mItems.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            mItems.RemoveAt(index);
        }

        public SoundPack this[int index]
        {
            get
            {
                return mItems[index];
            }
            set
            {
                mItems[index] = value;
            }
        }

        public void Add(SoundPack item)
        {
            mItems.Add(item);
        }

        public void Clear()
        {
            mItems.Clear();
        }

        public bool Contains(SoundPack item)
        {
            return mItems.Contains(item);
        }

        public void CopyTo(SoundPack[] array, int arrayIndex)
        {
            mItems.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return mItems.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(SoundPack item)
        {
            return mItems.Remove(item);
        }

        public IEnumerator<SoundPack> GetEnumerator()
        {
            return mItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mItems.GetEnumerator();
        }
    }

    [Serializable]
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
