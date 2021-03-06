//    CANAPE Network Testing Tool
//    Copyright (C) 2014 Context Information Security
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CANAPE.Net.Utils;

namespace CANAPE.Documents.Net
{
    /// <summary>
    /// A class to hold a connection history
    /// </summary>
    [Serializable]    
    public class ConnectionHistory : ObservableCollection<ConnectionHistoryEntry>
    {
        /// <summary>
        /// Get a connection entry by ID
        /// </summary>
        /// <param name="netId">The network ID</param>
        /// <returns>The connection history entry</returns>
        public ConnectionHistoryEntry GetConnectionById(Guid netId)
        {
            lock (this)
            {
                foreach (ConnectionHistoryEntry entry in this)
                {
                    if (entry.NetId == netId)
                    {
                        return entry;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Get a connection entry by ID
        /// </summary>
        /// <param name="netId">The network ID</param>
        /// <returns>The connection history entry</returns>
        public ConnectionHistoryEntry GetConnectionById(string netId)
        {
            Guid g;

            if (Guid.TryParse(netId, out g))
            {
                return GetConnectionById(g);
            }

            return null;
        }
    }
}
