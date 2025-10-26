<template>
  <div class="background">
    <div class="title">
      <h2>Employee Account Profiles</h2>
    </div>
      <div>
        <label>Email: </label>
        <input v-model="email" type="email" required class="boxx" />
      </div>
      <button class="btn" :disabled="loading" type="submit">
        {{ loading ? 'Submitting...' : 'Submit' }}
      </button>
      <div v-if="accounts && accounts.length > 0" class="layout">
        <table class="v-table">
          <thead>
            <tr>
              <th>FirstName</th>
              <th>Surname</th>
              <th>Email</th>
              <th>AccountId</th>
              <th>Created</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="acc in accounts" :key="acc.accountId">
              <td>{{ acc.firstName }}</td>
              <td>{{ acc.surname }}</td>
              <td>{{ acc.accountId }}</td>
              <td>{{ acc.email }}</td>
              <td>{{ new Date(acc.createdDate).toLocaleString() }}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div v-else-if="!loading && (!accounts || accounts.length === 0)">
        <p>No accounts found.</p>
      </div>
    </div>
</template>

<script lang="js">
  import { defineComponent } from 'vue';
  export default defineComponent({
    name: 'AccountProfile',
    data() {
      return {
        accounts: [],
        message: '',
        loading: false
      };
    },

    created() {
      this.fetchAccountData()
    },

    methods: {
      async fetchAccountData() {
        this.message = ''
        this.loading = true

        try {
          const response = await fetch('maham/account/fetchAccounts', {
            method: 'GET',
            headers: {
              'Accept': 'application/json'
            }
          });

          if (!response.ok) {
            throw new Error(`Server error: ${response.status}`);
          }

          const result = await response.json();
          this.accounts = result;
        } catch (err) {
          console.error(err);
          this.message = `Failed to load accounts: ${err.message}`;
        } finally {
          this.loading = false;
        }
      }
    }
  });
</script>
<style scoped>
  .layout {
    padding-left: calc(var(--section-gap) / 5);
    padding-top: calc(var(--section-gap) / 5);
  }
  .background {
    position: fixed;
    left: 400px;
    top: 100px;
    background-color: #02575C;
    height: 70%;
    width: 40%;
    border-end-end-radius: 50px;
  }
  .title {
    color: #F8F0DD;
    line-height: 2;
    padding-left: calc(var(--section-gap) / 5);
    font-family: "Permanent Marker", cursive;
  }
  .btn {
    position:absolute;
    left:400px;
    padding-left: calc(var(--section-gap) / 5);
    color: white;
    background-color: darkred;
    border-radius: 5px;
  }
  .boxx {
    border-radius: 5px;
    border-color: grey;
    border-width: 1px;
  }
  .v-table {
    border-collapse: collapse;
    background: #66AC8D;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
    border-end-end-radius: 50px;
    overflow: hidden;
    width:95%;
  }
  .v-table th {
    background-color: #E2F397;
    color: #02575C;
    font-weight: 600;
    padding: 12px;
    text-align: left;
    border-bottom: 2px solid #e5e9f0;
  }
  .v-table td {
    padding: 12px;
    border-bottom: 1px solid #e5e9f0;
    text-align: left;
    color: #E2F397;
  }
    .v-table tr:hover {
      background-color: #5CBB8D;
      transition: 0.2s ease;
    }
</style>
