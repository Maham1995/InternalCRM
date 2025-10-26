<script setup>
  import OnboardingForm from './components/OnboardingForm.vue'
  import AccountProfile from './components/AccountProfile.vue'
</script>

  <template>
    <header class="navbar">
      <meta charset="utf-8">
      <link href="https://fonts.googleapis.com/css2?family=Permanent+Marker&display=swap" rel="stylesheet">
      <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="50" height="50" />
      <h1>Internal Employees Portal</h1>
    </header>

    <main>
      <OnboardingForm />
      <AccountProfile/>
    </main>
  </template>

<style scoped>
  header {
    line-height: 2;
    position: fixed;
    left: 0;
    top: 0;
    color: #02575C;
    font-family: "Permanent Marker", cursive;
  }
  .navbar {
    position: fixed;
    background-color: #E2F397;
    top: 0;
    left: 0;
    width: 100%;
  }

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    padding: calc(var(--section-gap) / 10);
  }

  .logo {
    margin: 0 1rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
