import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import authService from './api-authorization/AuthorizeService';

class AddWordForm extends Component {
  constructor(props) {
    super(props);
    this.state = { body: '', meaning: '' };
  }

  render() {
    return (
      <Form
        onSubmit={async () => {
          const token = await authService.getAccessToken();
          await fetch('api/words', {
            method: 'POST',
            headers: {
              Authorization: `Bearer ${token}`,
              Accept: 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              body: this.state.body,
              meaning: this.state.meaning,
            }),
          });
        }}
      >
        <FormGroup>
          <Label for="formWord">Word</Label>
          <Input
            required
            type="text"
            name="word"
            id="formWord"
            placeholder="Enter a word"
            onChange={(e) => {
              this.setState({ body: e.target.value });
            }}
          />
        </FormGroup>

        <FormGroup>
          <Label for="formMeaning">Meaning</Label>
          <Input
            required
            type="text"
            name="meaning"
            id="formMeaning"
            placeholder="Enter a meaning"
            onChange={(e) => {
              this.setState({ meaning: e.target.value });
            }}
          />
        </FormGroup>

        <Button color="primary">Add</Button>
      </Form>
    );
  }
}

export default AddWordForm;
