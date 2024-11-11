import React from 'react';
import TodoList from './components/TodoList';
import './styles.css';

const App: React.FC = () => {
  return (
    <div className="App">
      <TodoList />
    </div>
  );
};

export default App;
