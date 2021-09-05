import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import authService from './api-authorization/AuthorizeService';

class AddWordForm extends Component {
  render() {
    return (
      // <Form>
      //   <FormGroup>
      //     <Label for="formWord">Word</Label>
      //     <Input
      //       type="text"
      //       name="word"
      //       id="formWord"
      //       placeholder="Enter a word"
      //     />
      //   </FormGroup>

      //   <FormGroup>
      //     <Label for="formMeaning">Meaning</Label>
      //     <Input
      //       type="text"
      //       name="meaning"
      //       id="formMeaning"
      //       placeholder="Enter a meaning"
      //     />
      //   </FormGroup>

      //   <Button>Add</Button>
      // </Form>
      <Button
        onClick={async () => {
          const token = await authService.getAccessToken();
          const response = await fetch('api/words', {
            method: 'POST',
            headers: {
              Authorization: `Bearer ${token}`,
              Accept: 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              body: 'new',
              meaning: 'try',
            }),
          });
          console.log(response);
        }}
      >
        Add
      </Button>
    );
  }
}

export default AddWordForm;
