import axios from 'axios';
import { TodoTask } from '../interfaces/Todo';

const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
});

export const fetchPendingTodos = async (): Promise<TodoTask[]> => {
    const response = await api.get('/pending');
    return response.data;
};

export const fetchOverdueTodos = async (): Promise<TodoTask[]> => {
    const response = await api.get('/overdue');
    return response.data;
};

export const addTodo = async (title: string, dueDate: string | null): Promise<TodoTask> => {
    const response = await api.post('/', { title, dueDate });
    return response.data;
};

export const markTaskAsCompleted = async (id: number): Promise<void> => {
    await api.put(`/${id}/complete`);
};

export const updateTodo = async (id: number, title: string, dueDate: Date | null): Promise<void> => {
    await api.put(`/${id}`, {
        title,
        dueDate: dueDate ? dueDate.toISOString() : null,
    });
};

export const deleteTodo = async (id: number): Promise<void> => {
    await api.delete(`/${id}`);
};

export const fetchCompletedTodos = async (): Promise<TodoTask[]> => {
    const response = await api.get('/completed');
    return response.data;
};