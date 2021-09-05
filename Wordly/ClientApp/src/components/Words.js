import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';
import AddWordForm from './AddWordForm';
import { DeleteWordButton } from './DeleteWordButton';

export class Words extends Component {
  constructor(props) {
    super(props);
    this.state = { words: [], loading: true };
  }

  componentDidMount() {
    this.populateWordsData();
  }

  static renderWordsTable(words) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Word</th>
            <th>Meaning</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {words.map((word) => (
            <tr key={word.id}>
              <td>{word.body}</td>
              <td>{word.meaning}</td>
              <td>
                <DeleteWordButton wordId={word.id} />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      Words.renderWordsTable(this.state.words)
    );

    return (
      <div>
        <h1 id="tabelLabel">My Words</h1>
        {contents}

        <AddWordForm />
      </div>
    );
  }

  async populateWordsData() {
    const token = await authService.getAccessToken();
    const response = await fetch('api/words', {
      headers: !token ? {} : { Authorization: `Bearer ${token}` },
    });
    const data = await response.json();
    this.setState({ words: data, loading: false });
  }
}
