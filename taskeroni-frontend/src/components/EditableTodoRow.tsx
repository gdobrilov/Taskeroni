import React, { useState } from 'react';
import { TodoTask } from '../interfaces/Todo';
import {
    TableCell, TableRow, TextField, IconButton, Checkbox
} from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { CheckCircle, RadioButtonUnchecked, Edit, Delete, Save, Close } from '@mui/icons-material';

interface EditableTodoRowProps {
    todo: TodoTask;
    onToggleCompletion?: (id: number) => void;
    onSave?: (id: number, title: string, dueDate: Date | null) => void;
    onDelete?: (id: number) => void;
    readOnly?: boolean;
}

const EditableTodoRow: React.FC<EditableTodoRowProps> = ({ todo, onToggleCompletion, onSave, onDelete, readOnly = false }) => {
    const [isEditing, setIsEditing] = useState(false);
    const [editData, setEditData] = useState<{ title: string; dueDate: Date | null }>({
        title: todo.title,
        dueDate: todo.dueDate ? new Date(todo.dueDate) : null,
    });

    const handleSave = () => {
        if (onSave) {
            onSave(todo.id, editData.title, editData.dueDate);
            setIsEditing(false);
        }
    };

    const handleCancel = () => {
        setIsEditing(false);
        setEditData({ title: todo.title, dueDate: todo.dueDate ? new Date(todo.dueDate) : null });
    };

    return (
        <TableRow>
            <TableCell>
                {isEditing ? (
                    <TextField
                        value={editData.title}
                        onChange={(e) => setEditData({ ...editData, title: e.target.value })}
                        variant="outlined"
                    />
                ) : (
                    todo.title
                )}
            </TableCell>
            <TableCell>
                {isEditing ? (
                    <LocalizationProvider dateAdapter={AdapterDateFns}>
                        <DatePicker
                            value={editData.dueDate}
                            onChange={(newDate) => setEditData({ ...editData, dueDate: newDate })}
                            renderInput={(params) => <TextField {...params} variant="outlined" />}
                        />
                    </LocalizationProvider>
                ) : (
                    todo.dueDate ? new Date(todo.dueDate).toLocaleDateString() : 'N/A'
                )}
            </TableCell>
            <TableCell>
                <Checkbox
                    checked={todo.completed}
                    icon={<RadioButtonUnchecked />}
                    checkedIcon={<CheckCircle color="success" />}
                    onChange={() => onToggleCompletion && onToggleCompletion(todo.id)}
                    disabled={readOnly}  // Disable checkbox if read-only
                />
            </TableCell>
            {!readOnly && (
                <TableCell>
                    {isEditing ? (
                        <>
                            <IconButton color="primary" onClick={handleSave}>
                                <Save />
                            </IconButton>
                            <IconButton color="secondary" onClick={handleCancel}>
                                <Close />
                            </IconButton>
                        </>
                    ) : (
                        <>
                            <IconButton color="primary" onClick={() => setIsEditing(true)}>
                                <Edit />
                            </IconButton>
                            <IconButton color="error" onClick={() => onDelete && onDelete(todo.id)}>
                                <Delete />
                            </IconButton>
                        </>
                    )}
                </TableCell>
            )}
        </TableRow>
    );
};

export default EditableTodoRow;
