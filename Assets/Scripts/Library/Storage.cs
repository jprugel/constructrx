using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Inventories {
    [Serializable]
    public class Storage<TStorable> : IEnumerable where TStorable : IStorable {
        private int _maximumSize; 
        [SerializeField] private List<TStorable> _storables = new List<TStorable>();

        public delegate void StorageHandler(TStorable storable);
        public event StorageHandler OnStorageUpdate;

        public List<TStorable> Storables {
            get => _storables;
            private set => _storables = value;
        }

        public Storage(int maximumSize = 1) {
            _maximumSize = maximumSize;
        }

        public void AddStorable(TStorable storable) {
            Storables.Add(storable);
            OnStorageUpdate?.Invoke(storable);
        }

        public void RemoveStorable(TStorable storable) {
            Storables.Remove(storable);
            OnStorageUpdate?.Invoke(storable);
        }

        public void TransferStorable(Storage<TStorable> storage, TStorable storable) {
            Storables.Remove(storable);
            storage.AddStorable(storable);
            OnStorageUpdate?.Invoke(storable);
        }

        public IEnumerator GetEnumerator() {
            return new StorageEnumerator(Storables);
        }

        #region Storage Enumerator
        public class StorageEnumerator : IEnumerator {
            public List<TStorable> Storables;
            public int index = -1;

            public StorageEnumerator(List<TStorable> storables) {
                Storables = storables;
            }

            private IEnumerator GetEnumerator() {
                return (IEnumerator)this;
            }

            public bool MoveNext() {
                index++;
                return (index < Storables.Count);
            }

            public void Reset() {
                index = -1;
            }

            public object Current { 
                get {
                    try {
                        return Storables[index]; 
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        #endregion
    }

    public interface IStorable {
        public string Id { get; set; }
    }
}
