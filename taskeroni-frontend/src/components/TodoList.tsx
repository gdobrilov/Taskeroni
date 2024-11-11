import React, { useEffect, useState } from 'react';
import {
    fetchPendingTodos,
    fetchOverdueTodos,
    fetchCompletedTodos,
    addTodo,
    markTaskAsCompleted,
    updateTodo,
    deleteTodo,
} from '../services/api';
import { TodoTask } from '../interfaces/Todo';
import AddTodoForm from './AddTodoForm';
import TodoTable from './TodoTable';
import { Typography, Box } from '@mui/material';

const TodoList: React.FC = () => {
    const [pendingTodos, setPendingTodos] = useState<TodoTask[]>([]);
    const [overdueTodos, setOverdueTodos] = useState<TodoTask[]>([]);
    const [completedTodos, setCompletedTodos] = useState<TodoTask[]>([]);

    const fetchTasks = async () => {
        try {
            const pending = await fetchPendingTodos();
            const overdue = await fetchOverdueTodos();
            const completed = await fetchCompletedTodos();
            setPendingTodos(pending);
            setOverdueTodos(overdue);
            setCompletedTodos(completed);
        } catch (error) {
            console.error("Error fetching tasks:", error);
        }
    };

    useEffect(() => {
        fetchTasks();
    }, []);

    const handleAddTodo = async (title: string, dueDate: string | null) => {
        try {
            await addTodo(title, dueDate);
            fetchTasks();
        } catch (error) {
            console.error("Error adding todo:", error);
        }
    };

    const handleToggleCompletion = async (id: number) => {
        try {
            await markTaskAsCompleted(id);
            fetchTasks(); // Refresh the task list
        } catch (error) {
            console.error("Error marking task as completed:", error);
        }
    };

    const handleSave = async (id: number, title: string, dueDate: Date | null) => {
        try {
            await updateTodo(id, title, dueDate);
            fetchTasks();
        } catch (error) {
            console.error("Error updating todo:", error);
        }
    };

    const handleDelete = async (id: number) => {
        try {
            await deleteTodo(id);
            fetchTasks();
        } catch (error) {
            console.error("Error deleting todo:", error);
        }
    };

    return (
        <Box>
            <Typography variant="h3" color="primary">Taskeroni To-Do List</Typography>
            <AddTodoForm onAddTodo={handleAddTodo} />

            <TodoTable
                title="Pending Tasks"
                todos={pendingTodos}
                onToggleCompletion={handleToggleCompletion}
                onSave={handleSave}
                onDelete={handleDelete}
            />
            <TodoTable
                title="Overdue Tasks"
                todos={overdueTodos}
                onToggleCompletion={handleToggleCompletion}
                onSave={handleSave}
                onDelete={handleDelete}
            />

            {/* Read-Only Completed Tasks Table */}
            <TodoTable title="Completed Tasks" todos={completedTodos} readOnly />
        </Box>
    );
};

export default TodoList;
