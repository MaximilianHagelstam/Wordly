import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

class AddWordForm extends Component {
  render() {
    return (
      <Form>
        <FormGroup>
          <Label for="formWord">Word</Label>
          <Input
            type="text"
            name="word"
            id="formWord"
            placeholder="Enter a word"
          />
        </FormGroup>

        <FormGroup>
          <Label for="formMeaning">Meaning</Label>
          <Input
            type="text"
            name="meaning"
            id="formMeaning"
            placeholder="Enter a meaning"
          />
        </FormGroup>

        <Button>Add</Button>
      </Form>
    );
  }
}

export default AddWordForm;
