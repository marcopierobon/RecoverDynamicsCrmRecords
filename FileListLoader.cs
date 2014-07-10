using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RestoreRecords.Interfaces;
namespace RestoreRecords
{
    class FileListLoader:IListLoader
    {
        private readonly List<Guid> _guidList = null;
        private readonly string _filePath = null;

        public FileListLoader(string filePath)
        {
            _guidList = new List<Guid>();
            this._filePath = filePath;
        }

        public List<Guid> LoadGuidList()
        {
            using (var streamReader = new StreamReader(_filePath))
            {
                while (streamReader.Peek() >= 0)
                {
                    var nextValue = streamReader.ReadLine();
                    if (_guidList != null && nextValue!= null)
                        _guidList.Add(Guid.Parse(nextValue));
                }
            }
            return _guidList;
        }

    }
}
