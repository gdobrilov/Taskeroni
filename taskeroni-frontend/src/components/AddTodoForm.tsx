import React, { useState } from 'react';
import { TextField, Button, Box } from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';

interface AddTodoFormProps {
    onAddTodo: (title: string, dueDate: string | null) => void;
}

const AddTodoForm: React.FC<AddTodoFormProps> = ({ onAddTodo }) => {
    const [title, setTitle] = useState('');
    const [dueDate, setDueDate] = useState<Date | null>(null);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (title.trim()) {
            // Send the formatted date if available, otherwise send null
            const formattedDueDate = dueDate ? dueDate.toISOString() : null;
            onAddTodo(title, formattedDueDate);
            setTitle('');
            setDueDate(null);
        }
    };

    return (
        <LocalizationProvider dateAdapter={AdapterDateFns}>
            <Box
                component="form"
                onSubmit={handleSubmit}
                sx={{
                    display: 'flex',
                    alignItems: 'center',
                    gap: 1,
                    marginTop: 2,
                }}
            >
                <TextField
                    label="Add new task"
                    variant="outlined"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    sx={{
                        flexGrow: 1,
                        height: '56px',
                    }}
                    InputProps={{
                        style: { height: '100%', padding: '10px' },
                    }}
                />
                <DatePicker
                    label="Due Date"
                    value={dueDate}
                    onChange={(newDate) => setDueDate(newDate as Date | null)}
                    renderInput={(params) => (
                        <TextField {...params} variant="outlined" fullWidth sx={{ height: '56px' }} />
                    )}
                />
                <Button
                    type="submit"
                    variant="contained"
                    color="primary"
                    sx={{
                        height: '56px',
                        padding: '0 20px',
                        fontWeight: 'bold',
                    }}
                >
                    ADD TASK
                </Button>
            </Box>
        </LocalizationProvider>
    );
};

export default AddTodoForm;
