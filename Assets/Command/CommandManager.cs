using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class EntityCommandManager : MonoBehaviour {
        private readonly Stack<ICommand> _undoCommands = new Stack<ICommand>();
        
        private readonly Stack<ICommand> _redoCommands = new Stack<ICommand>();
        
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoCommands.Push(command);
            
            // Clear the redo stack
            _redoCommands.Clear();
        }
        
        
        public void Undo()
        {
            if (_undoCommands.Count == 0) return;
            ICommand command = _undoCommands.Pop();
            command.Undo();
            _redoCommands.Push(command);
        }
        
        public void Redo()
        {
            if (_redoCommands.Count == 0) return;
            ICommand command = _redoCommands.Pop();
            command.Execute();
            _undoCommands.Push(command);
        }
        
    }
}