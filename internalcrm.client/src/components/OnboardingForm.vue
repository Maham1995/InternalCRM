<template>
  <header>
    <meta charset="utf-8">
    <link href="https://fonts.googleapis.com/css2?family=Permanent+Marker&display=swap" rel="stylesheet">
  </header>
  <div class="background">
    <div class="title">
    <h2>Onboard New Account</h2>
    </div>
    <div class="formLayout">
    <form @submit.prevent="submitForm">
      <div>
        <label>First Name: </label>
        <input v-model="firstName" type="text" required class="boxx"/>
      </div>

      <div>
        <label>Surname: </label>
        <input v-model="surname" type="text" required class="boxx"/>
      </div>

      <div>
        <label>Email: </label>
        <input v-model="email" type="email" required class="boxx"/>
      </div>

      <button class="btn" :disabled="loading" type="submit">
        {{ loading ? 'Submitting...' : 'Submit' }}
      </button>
    </form>
    </div>

    <p v-if="message" class="mt-3">{{ message }}</p>
</div>
</template>

<script lang="js">
  import { defineComponent } from 'vue'

  export default defineComponent({
    name: 'OnboardingForm',

    data() {
      return {
        firstName: '',
        surname: '',
        email: '',
        message: '',
        loading: false
      }
    },

    methods: {
      async submitForm() {
        this.loading = true
        this.message = ''

        const accountData = {
          firstName: this.firstName,
          surname: this.surname,
          email: this.email
        }

        try {
          const response = await fetch('maham/account', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(accountData)
          })

          if (!response.ok) {
            throw new Error(`Server error: ${response.status}`)
          }

          const result = await response.json()
          this.message = `Account created for email: ${result.data}`
        } catch (err) {
          console.error(err)
          this.message = `Failed to create account: ${err.message}`
        } finally {
          this.loading = false
        }
      }
    }
  })
</script>

<style scoped>
  .background {
    position: fixed;
    left: 0;
    top: 100px;
    background-color: #5CBB8D;
    height: 40%;
    width: 20%;
    border-end-end-radius: 50px;
  }
  form {
    font-weight: normal;
    position: center;
    line-height: 2;
    color: #02575C;
  }
  .boxx {
    border-radius: 5px;
    border-color:grey;
    border-width:1px;
  }
  .formLayout {
    position: absolute;
    top: 50px;
    padding-left: calc(var(--section-gap) / 5);
    width: 150px;
  }
  .title {
    color: #F8F0DD;
    line-height: 2;
    padding-left: calc(var(--section-gap) / 5);
    font-family: "Permanent Marker", cursive;
    font-size:15px;
  }
  .btn {
    text-align: center;
    color: #02575C;
    background-color: #E2F397;
    border-radius: 5px;
  }
</style>

