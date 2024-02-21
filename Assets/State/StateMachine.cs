using System;
using System.Collections.Generic;
using Predicate;
using Transition;

namespace State
{
    public class StateMachine
    {
        private StateNode _current;
        private readonly Dictionary<Type, StateNode> _nodes = new();
        private readonly HashSet<ITransition> _anyTransitions = new();

        // Called on the update loop in the monobehaviour
        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                ChangeState(transition.To);
            }
            
            _current.State?.OnUpdate();
        }
        
        // Called on the fixed update loop in the monobehaviour
        public void FixedUpdate()
        {
            _current.State?.OnFixedUpdate();
        }

        // Set the initial state
        public void SetState(IState state)
        {
            _current = _nodes[state.GetType()];
            _current.State?.OnEnter();
        }
        
        // Change the current state to the new state
        void ChangeState(IState state)
        {
            if (state == _current.State) return;
            
            var previousState = _current.State;
            var nextState = _nodes[state.GetType()].State;
            
            previousState?.OnExit();
            nextState?.OnEnter();
            _current = _nodes[state.GetType()];
        }
        
        // Get the transition to the next state
        ITransition GetTransition()
        {
            foreach (var transition in _anyTransitions)
                if (transition.Condition.Evaluate())
                    return transition;
            
            foreach (var transition in _current.Transitions)
                if (transition.Condition.Evaluate())
                    return transition;

            return null;
        }
        
        // Add a transition from one state to another
        public void AddTransition(IState from, IState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }
        
        // Add a transition from any state to another
        public void AddAnyTransition(IState to, IPredicate condition)
        {
            _anyTransitions.Add(new Transition.Transition(GetOrAddNode(to).State, condition));
        }
        
        // Get or add a node to the state machine
        StateNode GetOrAddNode(IState state)
        {
            var node = _nodes.GetValueOrDefault(state.GetType());
            
            if (node == null)
            {
                node = new StateNode(state);
                _nodes.Add(state.GetType(), node);
            }

            return node;

        }
        
        // A node in the state machine
        // Contains the state and the transitions from that state
        class StateNode
        {
            public IState State { get; }
            public HashSet<ITransition> Transitions { get; }
        
            public StateNode(IState state)
            {
                State = state;
                Transitions = new HashSet<ITransition>();
            }
            
            public void AddTransition(IState to, IPredicate condition)
            {
                Transitions.Add(new Transition.Transition(to, condition));
            }
        }
    }
}
