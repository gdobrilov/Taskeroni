import React from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';
import { TodoTask } from '../interfaces/Todo';
import EditableTodoRow from './EditableTodoRow';

interface TodoTableProps {
    title: string;
    todos: TodoTask[];
    onToggleCompletion?: (id: number) => void;
    onSave?: (id: number, title: string, dueDate: Date | null) => void;
    onDelete?: (id: number) => void;
    readOnly?: boolean;
}

const TodoTable: React.FC<TodoTableProps> = ({ title, todos, onToggleCompletion, onSave, onDelete, readOnly = false }) => (
    <Paper elevation={3} style={{ marginTop: '20px' }}>
        <TableContainer>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>{title}</TableCell>
                        <TableCell>Due Date</TableCell>
                        <TableCell>Completed</TableCell>
                        {!readOnly && <TableCell>Actions</TableCell>}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {todos.map((todo) => (
                        <EditableTodoRow
                            key={todo.id}
                            todo={todo}
                            onToggleCompletion={onToggleCompletion}
                            onSave={onSave}
                            onDelete={onDelete}
                            readOnly={readOnly}
                        />
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    </Paper>
);

export default TodoTable;
