import React from 'react';
import { Button } from 'reactstrap';
import authService from './api-authorization/AuthorizeService';

export const DeleteWordButton = ({ wordId }) => {
  const deleteWord = async () => {
    const token = await authService.getAccessToken();
    await fetch(`api/words${wordId}`, {
      method: 'DELETE',
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
  };

  return (
    <Button color="danger" onClick={deleteWord}>
      Delete
    </Button>
  );
};
