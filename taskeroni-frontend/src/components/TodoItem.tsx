import React from 'react';
import { TodoTask } from '../interfaces/Todo';

interface TodoItemProps {
    todo: TodoTask;
    onToggle: (id: number, completed: boolean) => void;
}

const TodoItem: React.FC<TodoItemProps> = ({ todo, onToggle }) => {
    return (
        <div>
            <label>
                <input
                    type="checkbox"
                    checked={todo.completed}
                    onChange={() => onToggle(todo.id, !todo.completed)}
                />
                {todo.completed ? <s>{todo.title}</s> : todo.title}
            </label>
        </div>
    );
};

export default TodoItem;
