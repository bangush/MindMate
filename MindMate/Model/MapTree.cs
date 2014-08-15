﻿/* Author: Syed Umar Anis (mail@umaranis.com)                    
 * Copyright (c) 2014 Syed Umar Anis                             
 * This software is license under MIT license (see LICENSE.txt)    
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Globalization;
using MindMate.Model;

namespace MindMate.Model
{

    public class MapTree
    {
        public MapTree(string rootNodeText) : this() 
        {
            new MapNode(this, rootNodeText); // creates root node
        }

        public MapTree() 
        {
            selectedNodes = new SelectedNodes();
        }

        private MapNode rootNode;
        public MapNode RootNode { 
            get
            {
                return rootNode;
            }
            set
            {
                if(rootNode != null) ClearTree();
                rootNode = value;
            }
        }

        private SelectedNodes selectedNodes;
        public SelectedNodes SelectedNodes
        {
            get
            {
                return selectedNodes;
            }
        } 


        private void ClearTree()
        {
            // may want to add some code here to assist garbage collection
            //this.RootNode.Icons.Clear();
            this.RootNode.NodeView = null;            
        }
                     
        
        /// <summary>
        /// Finds the first node that matches the provided condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>MapNode that matches the condition or null if no such node found</returns>
        public MapNode Find(Func<MapNode, bool> condition)
        {
            return this.rootNode.Find(condition);            
        }       
        
        public List<MapNode> FindAll(Func<MapNode, bool> condition)
        {
            return this.rootNode.FindAll(condition);            
        }

        public void ForEach(Action<MapNode> action)
        {
            this.rootNode.ForEach(action);
        }


        #region "Node Change Events"
        public event Action<MapNode, NodePropertyChangedEventArgs> NodePropertyChanged = delegate { };
        public event Action<MapNode, TreeStructureChangedEventArgs> TreeStructureChanged = delegate { };
        public event Action<MapNode, IconChangedEventArgs> IconChanged = delegate { };

        internal void FireEvent(MapNode node, NodeProperties property, object oldValue)
        {
            var args = new NodePropertyChangedEventArgs()
            {
                ChangedProperty = property,
                OldValue = oldValue
            };

            NodePropertyChanged(node, args);
        }

        internal void FireEvent(MapNode node, TreeStructureChange change)
        {
            var args = new TreeStructureChangedEventArgs()
            {
                ChangeType = change
            };

            TreeStructureChanged(node, args);
        }

        internal void FireEvent(MapNode node, IconChange change, string icon)
        {
            var args = new IconChangedEventArgs()
            {
                ChangeType = change,
                Icon = icon
            };

            IconChanged(node, args);
        }

        #endregion

    }
}
