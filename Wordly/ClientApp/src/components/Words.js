import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';
import { AddWordForm } from './AddWordForm';

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
          </tr>
        </thead>
        <tbody>
          {words.map((words) => (
            <tr key={words.id}>
              <td>{words.body}</td>
              <td>{words.meaning}</td>
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
        <h1 id="tabelLabel">Word</h1>
        <p>This component demonstrates fetching words from the server.</p>
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
